
using Microsoft.EntityFrameworkCore;
using Library.Data;

namespace Library.App;
public class LibraryApp
{
    public static void Main()
    {
        var options = new DbContextOptionsBuilder<LibraryContext>()
            .UseSqlite(LibraryContext.ConnectionString)
            .Options;

        var db = new LibraryContext(options);
    }
}