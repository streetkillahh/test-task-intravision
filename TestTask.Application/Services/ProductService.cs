// ProductService.cs
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VendingMachine.Domain.Dto;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Interfaces.Repositories;
using VendingMachine.Domain.Interfaces.Services;

namespace VendingMachine.Application.Services;

public class ProductService : IProductService
{
    public Task<List<ProductDto>> FilterAsync(string? brand, decimal? minPrice, decimal? maxPrice)
    {
        throw new NotImplementedException();
    }

    public Task<List<ProductDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProductDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
