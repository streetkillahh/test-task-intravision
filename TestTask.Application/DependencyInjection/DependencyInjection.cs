using Microsoft.Extensions.DependencyInjection;
using VendingMachine.Application.Services;
using VendingMachine.Domain.Interfaces.Services;

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
