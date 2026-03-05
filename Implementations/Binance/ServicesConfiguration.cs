using exchange.platform.binance.Providers;
using exchange.platform.clients.abstractions.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace exchange.platform.binance;

public static class ServicesConfiguration
{
    public static void ConfigureBinanceServices(this IServiceCollection services)
    {
        services.AddHttpClient<IExchangePriceProvider, BinancePriceProvider>(client =>
        {
            client.BaseAddress = new Uri("https://api.binance.com");
        });
    }
}