using VendingMachine.Domain.Entities;

namespace VendingMachine.Domain.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    IBaseRepository<Product> Products { get; }
    IBaseRepository<Order> Orders { get; }
    IBaseRepository<Coin> Coins { get; }
    IBaseRepository<Brand> Brands { get; }

    Task<int> SaveChangesAsync();
}