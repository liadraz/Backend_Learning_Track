
namespace Library.Models;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public ICollection<Book> Books { get; set; } = new List<Book>();

    public Author() { }

    public Author(string authorName)
    {
        Name = authorName;
    }
}