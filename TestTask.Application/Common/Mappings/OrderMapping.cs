using AutoMapper;
using VendingMachine.Application.Common.Mappings;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Dto;

namespace VendingMachine.Application.Mapping;

public class OrderMapping : IMapWith<Order>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Order, OrderDto>();
        profile.CreateMap<OrderItem, OrderItemDto>();
    }
}