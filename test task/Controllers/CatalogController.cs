using Microsoft.AspNetCore.Mvc;

namespace test_task.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
