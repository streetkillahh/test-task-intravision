namespace VendingMachine.Domain.Entities;

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public Order Order { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public string BrandName { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal PricePerItem { get; set; }
}