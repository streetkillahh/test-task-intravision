// OrderService.cs
using AutoMapper;
using VendingMachine.Domain.Dto;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Interfaces.Repositories;
using VendingMachine.Domain.Interfaces.Services;

namespace VendingMachine.Application.Services;

public class OrderService : IOrderService
{
    public Task<int> CreateOrderAsync(List<OrderItemDto> items)
    {
        throw new NotImplementedException();
    }

    public Task<OrderDto?> GetOrderByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}