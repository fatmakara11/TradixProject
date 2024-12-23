using TradixProject.DataAccessLayer.Concrete;
using TradixProject.DataAccessLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();

// Register BitcoinRepository and ensure it uses IConfiguration
builder.Services.AddScoped<IBitcoinRepository, BitcoinRepository>();

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CustomerLayout}/{action=Index}/{id?}");

app.Run();