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
            return View();
        }
        // оплата
        [HttpPost]
        public IActionResult Payment([FromBody] decimal total)
        {
            ViewBag.Total = total;
            return View();
        }


        [HttpPost]
        public IActionResult Receive([FromBody] List<DrinkViewModel> drinks)
        {
            if (drinks == null || drinks.Count == 0)
                return View("Empty");

            return View("Index", drinks);
        }
    }
}
