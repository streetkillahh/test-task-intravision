using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using test_task.Models;
using test_task.ViewModel;
using TestTask.Domain.Interfaces.Services;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Interfaces.Services;

namespace test_task.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IBaseRepository<Product> _productRepository; // <Product>
        private readonly IBaseRepository<Brand> _brandRepository; // <branbd>

        public HomeController(ILogger<HomeController> logger, IProductService productService, IBaseRepository<Product> productRepository)
        {
            _logger = logger;
            _productService = productService;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var brand = new Brand()
            {
                Id = 1,
                Name = "Sprite",

            };
            var product = new Product()
            {
                Id = 1,
                Name = "Напиток газированный Sprite",
                Price = 83,
                ImageUrl = "/images/sprite.png",
                Brand = brand
            };
            await _brandRepository.AddAsync(brand);
            await _productRepository.AddAsync(product);

            var drinks = new List<DrinkViewModel>
            {
                new DrinkViewModel { Name = "Напиток газированный Sprite", Price = 83, ImageUrl = "/images/sprite.png", IsAvailable = true, IsSelected = true },
                new DrinkViewModel { Name = "Напиток газированный Fanta", Price = 98, ImageUrl = "/images/fanta.png", IsAvailable = true, IsSelected = false },
                new DrinkViewModel { Name = "Напиток газированный Coca-Cola", Price = 105, ImageUrl = "/images/cocacola.png", IsAvailable = true, IsSelected = false },
                new DrinkViewModel { Name = "Напиток газированный Dr. Pepper Zero", Price = 110, ImageUrl = "/images/drpepper.png", IsAvailable = false, IsSelected = false },
            };

            return View(drinks);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
