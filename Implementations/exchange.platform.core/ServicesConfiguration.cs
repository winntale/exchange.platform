using exchange.platform.abstractions.Operations.Price;
using exchange.platform.core.Operations;
using Microsoft.Extensions.DependencyInjection;

namespace exchange.platform.core;

public static class ServicesConfiguration
{
    public static void ConfigureCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IGetExchangePriceOperation, GetExchangePriceOperation>();
    }
}