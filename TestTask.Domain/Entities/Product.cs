namespace VendingMachine.Domain.Entities;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Quantity { get; set; }
    public string ImageUrl { get; set; } = string.Empty;

    public int BrandId { get; set; }

    public Brand Brand { get; set; } = null!;
}
