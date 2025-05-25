using System.Text.Json.Serialization;

namespace Library.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public int AuthorId { get; set; }

    [JsonIgnore]
    public Author? Author { get; set; }
}