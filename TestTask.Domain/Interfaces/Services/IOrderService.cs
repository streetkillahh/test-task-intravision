using VendingMachine.Domain.Dto;

namespace VendingMachine.Domain.Interfaces.Services;

public interface IOrderService
{
    Task<int> CreateOrderAsync(List<OrderItemDto> items);

    Task<OrderDto?> GetOrderByIdAsync(int id);
}
