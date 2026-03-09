using exchange.platform.binance.ExchangeClients;
using exchange.platform.clients.abstractions.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace exchange.platform.binance;

public static class ServicesConfiguration
{
    public static void ConfigureBinanceServices(this IServiceCollection services)
    {
        Console.WriteLine("ConfigureBinanceServices CALLED");

        services.AddHttpClient("Binance", client =>
        {
            client.BaseAddress = new Uri("https://api.binance.com");
        });

        services.AddKeyedTransient<IPriceExchangeClient, BinancePriceExchangeClient>("Binance");
    }
}