using System.Text.Json.Serialization;
using ChrisPieShop.App;
using ChrisPieShop.Models;
using ChrisPieShop.Models.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services for dependency injection
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(serviceProvider => ShoppingCart.GetCart(serviceProvider));
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => 
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddRazorPages();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); // add support for blazor server-side rendering

// DB Context
builder.Services.AddDbContext<ChrisPieShopDbContext>(options =>
{
    options.UseSqlServer(
            builder.Configuration["ConnectionStrings:ChrisPieShopDbContextConnection"]);
});

var app = builder.Build();

#region Middleware
// Middleware components that listens for incoming requests to the root of the application
// After build but before run
app.UseStaticFiles();
app.UseSession(); //Support for using sessions

// Only shown if the app is ran in a development setting
if (app.Environment.IsDevelopment())
{
    // Diagnostic exception page which may contain secret information
    app.UseDeveloperExceptionPage();
}

// Set defaults used typically in MVC to route to views
app.MapDefaultControllerRoute(); //{controller=Home/{action=Index}/{id?}}

#endregion

app.UseAntiforgery(); // required for blazor to work

app.MapRazorPages();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// seed the database if necessary
DbInitializer.Seed(app);

// Start of application
app.Run();
