using VendingMachine.Domain.Dto;

namespace VendingMachine.Domain.Interfaces.Services;

public interface ICartService
{
    Task AddToCartAsync(OrderItemDto item);

    Task<List<OrderItemDto>> GetCartAsync();

    Task RemoveFromCartAsync(int productId);

    Task ClearCartAsync();
}
