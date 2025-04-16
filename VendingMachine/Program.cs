using Microsoft.EntityFrameworkCore;
using VendingMachine.Domain.Interfaces.Services;
using VendingMachine.Application.Services;
using VendingMachine.Infrastructure.Seed;
using VendingMachine.Infrastructure;
using VendingMachine.Domain.Interfaces.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container (MVC + Razor Views)
builder.Services.AddControllersWithViews();

/// ����������� ��������� ���� ������
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ����������� ������������
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

// ����������� Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// ����������� ��������
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// ������������� ������
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    SeedData.Initialize(context);
}

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Default MVC route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();