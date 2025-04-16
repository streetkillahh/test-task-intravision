using VendingMachine.Domain.Dto;

namespace VendingMachine.Domain.Interfaces.Services;

public interface IProductService
{
    Task<List<ProductDto>> GetAllAsync();

    Task<List<ProductDto>> FilterAsync(string? brand, decimal? minPrice, decimal? maxPrice);

    Task<ProductDto?> GetByIdAsync(int id);
}
