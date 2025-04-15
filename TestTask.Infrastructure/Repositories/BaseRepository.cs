using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VendingMachine.Infrastructure;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public IQueryable<TEntity> GetAll()
    {
        return _dbSet.AsQueryable();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void Remove(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
