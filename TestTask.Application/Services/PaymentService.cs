using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Enums;
using VendingMachine.Domain.Dto;
using System.Linq;
using VendingMachine.Domain.Interfaces.Repositories;
using VendingMachine.Domain.Interfaces.Services;

namespace VendingMachine.Application.Services;

public class PaymentService : IPaymentService
{
    private readonly IBaseRepository<Order> _orderRepository;
    private readonly IBaseRepository<Coin> _coinRepository;

    public PaymentService(IUnitOfWork unitOfWork)
    {
        _orderRepository = unitOfWork.Orders;
        _coinRepository = unitOfWork.Coins;
    }

    public async Task<bool> TryProcessPaymentAsync(PaymentDto paymentDto)
    {
        var order = await _orderRepository.GetByIdAsync(paymentDto.OrderId);
        if (order == null) return false;

        var totalInserted = paymentDto.InsertedCoins.Sum(c => (int)c.Denomination * c.Quantity);
        var changeNeeded = (int)(totalInserted - order.TotalPrice);
        if (changeNeeded < 0) return false;

        var change = await CalculateChangeAsync(totalInserted, order.TotalPrice);
        if (change == null) return false;

        foreach (var coin in paymentDto.InsertedCoins)
        {
            var dbCoin = await _coinRepository.GetByIdAsync((int)coin.Denomination);
            if (dbCoin != null)
                dbCoin.Quantity += coin.Quantity;
        }

        foreach (var (denomination, qty) in change)
        {
            var dbCoin = await _coinRepository.GetByIdAsync(denomination);
            if (dbCoin != null)
                dbCoin.Quantity -= qty;
        }

        return true;
    }

    public async Task<Dictionary<int, int>?> CalculateChangeAsync(decimal totalInserted, decimal totalPrice)
    {
        var changeToGive = (int)(totalInserted - totalPrice);

        var allCoins = _coinRepository.GetAll();

        var coinInventory = allCoins
            .OrderByDescending(c => c.Denomination)
            .ToDictionary(c => (int)c.Denomination, c => c.Quantity);

        var result = new Dictionary<int, int>();

        foreach (var kvp in coinInventory)
        {
            int denom = kvp.Key;
            int available = kvp.Value;

            int count = Math.Min(changeToGive / denom, available);
            if (count > 0)
            {
                result[denom] = count;
                changeToGive -= count * denom;
            }

            if (changeToGive == 0)
                break;
        }

        return changeToGive == 0 ? result : null;
    }
}