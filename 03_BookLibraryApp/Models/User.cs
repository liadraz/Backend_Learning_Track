
namespace Library.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;

    public User() { }

    public User(string name)
    {
        Name = name;
    }
}