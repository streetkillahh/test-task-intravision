using Microsoft.AspNetCore.Mvc;
using test_task.ViewModel;

namespace test_task.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index(List<DrinkViewModel> selectedDrinks)
        {
            if (selectedDrinks == null || !selectedDrinks.Any())
            {
                return View("Empty");
            }

            return View(selectedDrinks);
        }

        public IActionResult FromStorage()
        {
            return View(); // отобразит FromStorage.cshtml, JS передаст данные
        }

        [HttpPost]
        public IActionResult Receive([FromBody] List<DrinkViewModel> drinks)
        {
            if (drinks == null || drinks.Count == 0)
                return View("Empty");

            TempData["Total"] = drinks.Sum(d => d.Price);
            return RedirectToAction("Payment");
        }

        public IActionResult Payment()
        {
            if (TempData["Total"] == null)
                return RedirectToAction("Index", "Home");

            ViewBag.Total = TempData["Total"];
            return View();
        }
    }
}
