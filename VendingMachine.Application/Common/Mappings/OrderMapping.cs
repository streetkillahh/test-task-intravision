using AutoMapper;
using VendingMachine.Application.Common.Mappings;
using VendingMachine.Domain.Dto;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Application.Mapping;

public class OrderMapping : IMapWith<Order>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Order, OrderDto>();
        profile.CreateMap<OrderItem, OrderItemDto>();
    }
}