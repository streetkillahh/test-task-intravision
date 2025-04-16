using VendingMachine.Domain.Entities;

public interface IProductRepository : IBaseRepository<Product>
{
    IQueryable<Product> Query(); // фильтрация без загрузки
}