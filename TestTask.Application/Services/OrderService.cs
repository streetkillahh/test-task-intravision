// OrderService.cs
using AutoMapper;
using VendingMachine.Domain.Dto;
using VendingMachine.Domain.Interfaces.Repositories;
using VendingMachine.Domain.Interfaces.Services;
using VendingMachine.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace VendingMachine.Application.Services;

public class OrderService : IOrderService
{
    private readonly IBaseRepository<Order> _orderRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _orderRepository = unitOfWork.Orders;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<int> CreateOrderAsync(List<OrderItemDto> items)
    {
        if (!items.Any())
            throw new InvalidOperationException("Заказ не может быть пустым");

        var total = items.Sum(i => i.Quantity * i.PricePerItem);

        var order = new Order
        {
            CreatedAt = DateTime.UtcNow,
            TotalPrice = total,
            Items = items.Select(i => new OrderItem
            {
                ProductId = i.ProductId,
                ProductName = i.ProductName,
                BrandName = i.BrandName,
                Quantity = i.Quantity,
                PricePerItem = i.PricePerItem
            }).ToList()
        };

        await _orderRepository.AddAsync(order);
        await _unitOfWork.SaveChangesAsync();

        return order.Id;
    }

    public async Task<OrderDto?> GetOrderByIdAsync(int id)
    {
        var order = await _orderRepository.GetAll()
            .Include(i => i.Items)
            .FirstOrDefaultAsync(x => x.Id == id);

        return order is null ? null : _mapper.Map<OrderDto>(order);
    }
}