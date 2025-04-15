using Microsoft.EntityFrameworkCore;
using VendingMachine.Domain.Entities;
using VendingMachine.Infrastructure;
using VendingMachine.DAL.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context) { }

    public IQueryable<Product> Query()
    {
        return _dbSet.Include(p => p.Brand).AsQueryable();
    }
}
