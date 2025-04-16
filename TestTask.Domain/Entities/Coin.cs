using VendingMachine.Domain.Enums;

namespace VendingMachine.Domain.Entities;

public class Coin
{
    public int Id { get; set; }

    public CoinType Denomination { get; set; } // 1, 2, 5, 10

    public int Quantity { get; set; }
}
