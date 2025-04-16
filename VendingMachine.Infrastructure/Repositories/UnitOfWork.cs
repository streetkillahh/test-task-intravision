using Microsoft.EntityFrameworkCore;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Interfaces.Repositories;
using VendingMachine.Infrastructure.Repositories;

namespace VendingMachine.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IBaseRepository<Product> Products { get; }
    public IBaseRepository<Order> Orders { get; }
    public IBaseRepository<Coin> Coins { get; }
    public IBaseRepository<Brand> Brands { get; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Products = new BaseRepository<Product>(context);
        Orders = new BaseRepository<Order>(context);
        Coins = new BaseRepository<Coin>(context);
        Brands = new BaseRepository<Brand>(context);
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