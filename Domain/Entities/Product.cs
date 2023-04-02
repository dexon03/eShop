namespace Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int AvailableCount { get; set; }
    public string Description { get; set; }
    public string ShortDescription { get; set; }
    public Guid CategoryId { get; set; }
    public string ImageUrl { get; set; }

    // Reference navigation properties
    public Category Category { get; set; }
}