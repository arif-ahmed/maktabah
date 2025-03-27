namespace Catalog.API.Models;
public class Book
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public Guid AuthorId { get; set; }
    public Guid CategoryId { get; set; }
    public string? ISBN { get; set; }
    public decimal Price { get; set; }
    public string? CoverImageUrl { get; set; }
    public int InventoryQuantity { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; }
}

