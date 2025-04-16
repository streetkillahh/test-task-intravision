using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Interfaces.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    IQueryable<Product> Query(); // фильтрация без загрузки
}