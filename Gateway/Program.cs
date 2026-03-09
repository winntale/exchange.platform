using exchange.platform.binance;
using exchange.platform.clients.abstractions.Providers;
using exchange.platform.Configurations;
using exchange.platform.core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// clients
builder.Services.ConfigureBinanceServices();

// core
builder.Services.ConfigureCoreServices();

// gateway
builder.Services.ConfigureAutoMapper();

builder.Services.ConfigureServices();
builder.Services.ConfigureSwaggerServices();

var app = builder.Build();

app.Services.ValidateMapperProfiles();

// swagger
app.ConfigureSwaggerPipeline();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();