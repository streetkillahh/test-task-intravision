using Microsoft.AspNetCore.Mvc;
using VendingMachine.Domain.Interfaces.Services;

namespace VendingMachine.Api.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductService _productService;

        public CatalogController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index(string? brand, decimal? minPrice, decimal? maxPrice)
        {
            var products = await _productService.FilterAsync(brand, minPrice, maxPrice);
            ViewBag.Brand = brand;
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;

            return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product is null)
                return NotFound();

            return View(product);
        }
    }
}
