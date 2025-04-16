using Microsoft.AspNetCore.Mvc;
using VendingMachine.Domain.Dto;
using VendingMachine.Domain.Interfaces.Services;

namespace VendingMachine.Api.Controllers;

public class CartController : Controller
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var cart = await _cartService.GetCartAsync();
        return View(cart);
    }

    [HttpPost]
    public async Task<IActionResult> Add(OrderItemDto item)
    {
        await _cartService.AddToCartAsync(item);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Remove(int productId)
    {
        await _cartService.RemoveFromCartAsync(productId);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Clear()
    {
        await _cartService.ClearCartAsync();
        return RedirectToAction("Index");
    }
}