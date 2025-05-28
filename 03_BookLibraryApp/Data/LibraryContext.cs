
using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.Data;

public class LibraryContext : DbContext
{
    public static string ConnectionString => "Data Source=library.db";

    public LibraryContext(DbContextOptions<LibraryContext> options)
    : base(options) { }

    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<User> Users => Set<User>();
}