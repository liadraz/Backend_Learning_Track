
using Microsoft.EntityFrameworkCore;

using Library.Data;
using Library.Services;
using Library.UI;

namespace Library.App;
public class LibraryApp
{
    public static void Main()
    {
        var options = new DbContextOptionsBuilder<LibraryContext>()
            .UseSqlite(LibraryContext.ConnectionString)
            .Options;

        using var context = new LibraryContext(options);
        var service = new LibraryService(context);

        var ui = new ConsoleUI(service);
        ui.Run();
    }
}