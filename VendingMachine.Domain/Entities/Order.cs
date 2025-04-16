namespace VendingMachine.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal TotalPrice { get; set; }
    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}