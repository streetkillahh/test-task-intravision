// PaymentController.cs
using Microsoft.AspNetCore.Mvc;
using VendingMachine.Domain.Dto;
using VendingMachine.Domain.Interfaces.Services;

namespace VendingMachine.Api.Controllers;

public class PaymentController : Controller
{
    private readonly IPaymentService _paymentService;
    private readonly IOrderService _orderService;

    public PaymentController(IPaymentService paymentService, IOrderService orderService)
    {
        _paymentService = paymentService;
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int orderId)
    {
        var order = await _orderService.GetOrderByIdAsync(orderId);
        if (order == null)
            return NotFound();

        return View(order);
    }

    [HttpPost]
    public async Task<IActionResult> Pay(PaymentDto payment)
    {
        var success = await _paymentService.TryProcessPaymentAsync(payment);
        if (!success)
        {
            TempData["Error"] = "Недостаточно средств или невозможно выдать сдачу.";
            return RedirectToAction("Index", new { orderId = payment.OrderId });
        }

        TempData["Success"] = "Оплата прошла успешно!";
        return RedirectToAction("Index", "Catalog");
    }
}
