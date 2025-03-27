namespace Catalog.API.Models;
public class Author
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Biography { get; set; }
}
