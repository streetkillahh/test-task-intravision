namespace VendingMachine.Domain.Dto;

public class PaymentDto
{
    public int OrderId { get; set; }

    public List<CoinDto> InsertedCoins { get; set; } = new();
}
