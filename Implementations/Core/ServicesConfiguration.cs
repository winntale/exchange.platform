using AutoMapper;
using Core.Abstractions.Operations.Price;
using exchange.platform.core.CoreModelsMappingProfiles;
using exchange.platform.core.Operations;
using Microsoft.Extensions.DependencyInjection;

namespace exchange.platform.core;

public static class ServicesConfiguration
{
    public static void ConfigureCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IGetExchangePriceOperation, GetExchangePriceOperation>();
    }
    
    public static void ConfigureCoreProfiles(this IMapperConfigurationExpression mc)
    {
        mc.AddMaps(typeof(ExchangePriceOperationProfile).Assembly);
    }
}