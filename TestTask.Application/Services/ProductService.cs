using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VendingMachine.Domain.Dto;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Interfaces.Repositories;
using VendingMachine.Domain.Interfaces.Services;

namespace VendingMachine.Application.Services;

public class ProductService : IProductService
{
    private readonly IBaseRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _productRepository = unitOfWork.Products;
        _mapper = mapper;
    }

    public async Task<List<ProductDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAll()
            .Include(p => p.Brand)
            .ToListAsync();

        return _mapper.Map<List<ProductDto>>(products);
    }

    public async Task<List<ProductDto>> FilterAsync(string? brand, decimal? minPrice, decimal? maxPrice)
    {
        var query = _productRepository.GetAll()
            .Include(p => p.Brand)
            .Where(p =>
                (string.IsNullOrWhiteSpace(brand) || p.Brand.Name == brand) &&
                (!minPrice.HasValue || p.Price >= minPrice.Value) &&
                (!maxPrice.HasValue || p.Price <= maxPrice.Value));

        var products = await query.ToListAsync();
        return _mapper.Map<List<ProductDto>>(products);
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await _productRepository.GetAll()
            .Include(p => p.Brand)
            .FirstOrDefaultAsync(p => p.Id == id);

        return product is null ? null : _mapper.Map<ProductDto>(product);
    }
}
