using VendingMachine.Domain.Dto;

namespace VendingMachine.Domain.Interfaces.Services;

public interface IPaymentService
{
    Task<bool> TryProcessPaymentAsync(PaymentDto paymentDto);

    Task<Dictionary<int, int>> CalculateChangeAsync(decimal totalInserted, decimal totalPrice);
}
