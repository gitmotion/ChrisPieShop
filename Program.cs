using ChrisPieShop.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services for dependency injection
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
builder.Services.AddScoped<IPieRepository, MockPieRepository>();

var app = builder.Build();

#region Middleware
// Middleware components that listens for incoming requests to the root of the application
// After build but before run
app.UseStaticFiles();

// Only shown if the app is ran in a development setting
if(app.Environment.IsDevelopment())
{
    // Diagnostic exception page which may contain secret information
    app.UseDeveloperExceptionPage();
}

// Set defaults used typically in MVC to route to views
app.MapDefaultControllerRoute();
#endregion

// Start of application
app.Run();
