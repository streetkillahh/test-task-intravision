namespace VendingMachine.Domain.Dto;

public class OrderDto
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public decimal TotalPrice { get; set; }

    public List<OrderItemDto> Items { get; set; } = new();
}
