using VendingMachine.Domain.Entities;
using VendingMachine.Infrastructure;
using VendingMachine.Domain.Interfaces.Repositories;

namespace VendingMachine.DAL.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IBaseRepository<Product> Products { get; }
    public IBaseRepository<Order> Orders { get; }
    public IBaseRepository<Coin> Coins { get; }

    // db.Orders.Add

    public UnitOfWork(
        AppDbContext context,
        IBaseRepository<Product> productRepository,
        IBaseRepository<Order> orderRepository,
        IBaseRepository<Coin>  coinRepository)
    {
        _context = context;
        Products = productRepository;
        Orders = orderRepository;
        Coins = coinRepository;
    }

    public async Task<int> SaveChangesAsync()
    {

        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
