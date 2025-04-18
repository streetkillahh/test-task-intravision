﻿public interface IBaseRepository<TEntity>
{
    IQueryable<TEntity> GetAll();
    Task<TEntity?> GetByIdAsync(int id);
    //Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);

    Task SaveChangesAsync();
}
