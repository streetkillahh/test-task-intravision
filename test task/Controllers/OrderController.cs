// OrderController.cs
using Microsoft.AspNetCore.Mvc;
using VendingMachine.Domain.Interfaces.Services;

namespace VendingMachine.Api.Controllers;

public class OrderController : Controller
{
    private readonly ICartService _cartService;
    private readonly IOrderService _orderService;

    public OrderController(ICartService cartService, IOrderService orderService)
    {
        _cartService = cartService;
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> Create()
    {
        var cartItems = await _cartService.GetCartAsync();
        if (!cartItems.Any())
        {
            TempData["Error"] = "Корзина пуста";
            return RedirectToAction("Index", "Cart");
        }

        var orderId = await _orderService.CreateOrderAsync(cartItems);
        await _cartService.ClearCartAsync();

        return RedirectToAction("Index", "Payment", new { orderId });
    }
}