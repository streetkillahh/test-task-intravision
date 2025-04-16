using AutoMapper;
using VendingMachine.Application.Common.Mappings;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Application.Common.Mappings.Orders;

public class OrderItemDto : IMapWith<OrderItem>
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string BrandName { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal PricePerItem { get; set; }

    public decimal Total => Quantity * PricePerItem;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<OrderItem, OrderItemDto>();
    }
}
