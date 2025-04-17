using Microsoft.AspNetCore.Mvc;
using TestTask.Domain.Interfaces.Services;

namespace VendingMachine.Api.Controllers;

public class ExcelImportController : Controller
{
    private readonly IExcelImportService _excelImportService;

    public ExcelImportController(IExcelImportService excelImportService)
    {
        _excelImportService = excelImportService;
    }

    [HttpGet]
    public IActionResult Upload()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            TempData["Error"] = "Файл не выбран или пуст.";
            return RedirectToAction("Upload");
        }

        try
        {
            using var stream = file.OpenReadStream();
            await _excelImportService.ImportProductsFromExcelAsync(stream);
            TempData["Success"] = "Товары успешно импортированы.";
        }
        catch (Exception ex)
        {
            TempData["Error"] = $"Ошибка при импорте: {ex.Message}";
        }

        return RedirectToAction("Upload");
    }
}
