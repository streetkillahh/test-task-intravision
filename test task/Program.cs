using TestTask.Application.Common.Mappings;
using VendingMachine.DAL.DependencyInjection;
using VendingMachine.Application.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container (MVC + Razor Views)
builder.Services.AddControllersWithViews();

// AutoMapper + Assembly Scanning
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
});

// ��������� ������������: DAL + Application
builder.Services.AddDal(builder.Configuration);           // ����������� DbContext � ������������
builder.Services.AddApplication();                        // ����������� �������� (ProductService � ��.)

var app = builder.Build();

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
