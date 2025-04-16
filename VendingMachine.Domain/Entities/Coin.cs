using VendingMachine.Domain.Enums;
namespace VendingMachine.Domain.Entities;

public class Coin
{
    public int Id { get; set; }
    public CoinType Denomination { get; set; }
    public int Quantity { get; set; }
}