namespace VendingMachine.Domain.Dto;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int BrandId { get; set; }
    public string BrandName { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
}