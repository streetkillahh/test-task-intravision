using AutoMapper;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Application.Common.Mappings.Orders;

public class OrderDto : IMapWith<Order>
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public decimal TotalPrice { get; set; }

    public List<OrderItemDto> Items { get; set; } = new();

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Order, VendingMachine.Domain.Dto.OrderDto>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
    }
}
