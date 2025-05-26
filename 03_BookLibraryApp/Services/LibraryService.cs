using Microsoft.EntityFrameworkCore;
using System.Linq;
using Library.Data;

namespace Library.Service;

public class LibraryService
{
    private readonly LibraryContext _context;

    public LibraryService(LibraryContext context)
    {
        _context = context;
    }

    public void AddBook(string title, string authorName)
    {
        var author = _context.Authors
            .FirstOrDefault(a => a.Name == authorName);

        if (author == null)
        {
            author = AddAuthor(authorName);
        }

        var book = new Book(title, author);

        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public Author CreateAuthor(string authorName)
    {
        var author = new Author(authorName);

        _context.Authors.Add(author);
        _context.SaveChanges();

        return author;
    }

    public void AddUser(string name)
    {
        var user = new User(name);

        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public List<Book> GetBooks()
    {
        return _context.Books
            .Include(b => b.Author)     // join two tables
            .AsNoTracking()             // optimization for readonly records
            .ToList();
    }

    public void UpdateBookTitle(string title, int id)
    {
        var bookToUpdate = _context.Books.Find(id);
        if (bookToUpdate is null)
        {
            throw new InvalidOperationException("Book is not exist");
        }

        bookToUpdate.Title = title;
        _context.SaveChanges();
    }

    public void UpdateAuthorName(string name, int id)
    {
        var authorToUpdate = _context.Authors.Find(id);
        if (authorToUpdate is null)
        {
            throw new InvalidOperationException("Author is not exist");
        }

        authorToUpdate.Name = name;
        _context.SaveChanges();
    }

    public void DeleteBook(int id)
    {
        var bookToDelete = _context.Books.Find(id);
        if (bookToDelete is null)
        {
            throw new InvalidOperationException("Book is not exist");
        }

        _context.Books.Remove(bookToDelete);
        _context.SaveChanges();
    }

    public void DeleteAuthor(int id)
    {
        var authorToDelete = _context.Authors.Find(id);
        if (authorToDelete is null)
        {
            throw new InvalidOperationException("Author is not exist");
        }

        _context.Authors.Remove(authorToDelete);
        _context.SaveChanges();
    }

    public int GetBookCountPerAuthorId(int id)
    {
        var author = _context.Authors.Find(id);
        if (author is null)
        {
            throw new InvalidOperationException("Author is not exist");
        }

        return _context.Books.Count(b => b.AuthorId == id);
    }

    public List<(string AuthorName, int BookCount)> GetBookCountForAllAuthors()
    {
        return _context.Authors
            .Include(a => a.Books)
            .AsNoTracking()
            .Select(a => (a.Name, a.Books.Count))
            .ToList();
    }
}

