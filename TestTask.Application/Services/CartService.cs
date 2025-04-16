using VendingMachine.Domain.Dto;
using VendingMachine.Domain.Interfaces.Services;

namespace VendingMachine.Application.Services;

public class CartService : ICartService
{
    private readonly List<OrderItemDto> _cart = new();

    public async Task AddToCartAsync(OrderItemDto item)
    {
        await Task.Run(() => 
        {
            var existing = _cart.FirstOrDefault(i => i.ProductId == item.ProductId);

            if (existing != null)
                existing.Quantity += item.Quantity;
            else
                _cart.Add(item);
        });
        
    }

    public async Task ClearCartAsync()
    {
        await Task.Run(() =>
        {
            _cart.Clear();
        });
    }

    public Task<List<OrderItemDto>> GetCartAsync()
    {
        return Task.FromResult(_cart);
    }

    public async Task RemoveFromCartAsync(int productId)
    {
        await Task.Run(() =>
        {
            _cart.RemoveAll(i => i.ProductId == productId);
        });
    }
}
