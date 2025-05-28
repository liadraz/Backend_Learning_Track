
using Library.Services;

namespace Library.UI;

public class ConsoleUI
{
    private readonly LibraryService _service;

    public ConsoleUI(LibraryService service)
    {
        _service = service;
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("=== Book Library ===");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. View All Books");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    ViewBooks();
                    break;
                case "3":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option.\n");
                    break;
            }

            Console.WriteLine("\nPress any key to return to the menu\n");
            Console.ReadKey();
        }
    }

    public void AddBook()
    {
        Console.Clear();
        Console.WriteLine("Add A Book to the Library");

        Console.Write("Enter book title: ");
        string? title = Console.ReadLine();

        if (String.IsNullOrWhiteSpace(title))
        {
            Console.Write("Error: discription cannot be empty");
            return;
        }

        if (_service.IsBookExists(title))
        {
            Console.Write("Error: Book already exists");
            return;
        }

        Console.Write("Enter the book author: ");
        string? authorName = Console.ReadLine();

        if (String.IsNullOrWhiteSpace(authorName))
        {
            Console.Write("Error: Book must have an author");
            return;
        }

        _service.CreateBook(title, authorName);
    }

    public void ViewBooks()
    {
        var books = _service.GetAllBooks();

        if (!books.Any())
        {
            Console.Write("No books found");
        }

        foreach (var book in books)
        {
            Console.WriteLine($"[{book.Id}] \"{book.Title}\" by {book.Author?.Name ?? "Unknown"}");
        }

        Console.WriteLine();
    }
}
