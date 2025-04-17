// ExcelImportService.cs
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using TestTask.Domain.Interfaces.Services;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Interfaces.Repositories;

namespace VendingMachine.Application.Services;

public class ExcelImportService : IExcelImportService
{
    private readonly IBaseRepository<Product> _productRepository;
    private readonly IBaseRepository<Brand> _brandRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ExcelImportService(IUnitOfWork unitOfWork)
    {
        _productRepository = unitOfWork.Products;
        _brandRepository = unitOfWork.Brands;
        _unitOfWork = unitOfWork;
    }

    public async Task ImportProductsFromExcelAsync(Stream excelStream)
    {
        using var workbook = new XLWorkbook(excelStream);
        var worksheet = workbook.Worksheets.First();

        foreach (var row in worksheet.RowsUsed().Skip(1)) // пропускаем заголовок
        {
            var brandName = row.Cell(1).GetString();
            var productName = row.Cell(2).GetString();
            var price = row.Cell(3).GetDouble();
            var quantity = row.Cell(4).GetValue<int>();

            var brand = await _brandRepository.GetAll()
                .FirstOrDefaultAsync(b => b.Name == brandName);

            if (brand == null)
            {
                brand = new Brand { Name = brandName };
                await _brandRepository.AddAsync(brand);
            }

            var product = new Product
            {
                Name = productName,
                Price = decimal.Parse(price.ToString()),
                Quantity = quantity,
                Brand = brand
            };

            await _productRepository.AddAsync(product);
        }
        await _unitOfWork.SaveChangesAsync();
    }
}