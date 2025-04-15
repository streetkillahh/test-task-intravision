using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VendingMachine.Domain.Entities;
using VendingMachine.Infrastructure;
using VendingMachine.DAL.Repositories;
using VendingMachine.Domain.Interfaces.Repositories;

namespace VendingMachine.DAL.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddDal(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
       
        services.AddScoped<AppDbContext>(provider =>
                provider.GetService<AppDbContext>());


        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IBaseRepository<Product>, BaseRepository<Product> >();
        services.AddScoped<IBaseRepository<Order>, BaseRepository<Order> >();
        services.AddScoped<IBaseRepository<Coin>, BaseRepository<Coin>>();



        return services;
    }
}
