using AutoMapper;
using exchange.platform.GatewayModelsMappingProfiles;

namespace exchange.platform.Configurations;

public static class ServicesConfiguration
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        // пока пустует, но тут точно будет контент
    }
    
    public static void ConfigureGatewayProfiles(this IMapperConfigurationExpression mc)
    {
        mc.AddMaps(typeof(PriceControllerMappingProfile).Assembly);
    }
}