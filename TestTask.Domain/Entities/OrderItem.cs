namespace VendingMachine.Domain.Entities;

public class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public Order Order { get; set; } = null!;

    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!; // фиксируется на момент заказа

    public string BrandName { get; set; } = null!; // тоже фиксируется

    public decimal PricePerItem { get; set; }

    public int Quantity { get; set; }
}
