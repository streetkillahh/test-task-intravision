using Microsoft.Extensions.DependencyInjection;
using VendingMachine.Domain.Interfaces.Services;
using VendingMachine.Application.Services;

namespace VendingMachine.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        //services.AddScoped<IOrderService, OrderService>();
        // позже: PaymentService, CartService

        return services;
    }
}
