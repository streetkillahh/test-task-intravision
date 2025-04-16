namespace VendingMachine.Domain.Dto;

public class OrderItemDto
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string BrandName { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal PricePerItem { get; set; }

    public decimal Total => Quantity * PricePerItem;
}
