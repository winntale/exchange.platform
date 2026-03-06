using AutoMapper;
using exchange.platform.core;

namespace exchange.platform.Configurations;

public static class AutoMapperConfiguration
{
    public static void ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(mc =>
        {
            mc.ConfigureGatewayProfiles();
            mc.ConfigureCoreProfiles();
        });
    }

    public static void ValidateMapperProfiles(this IServiceProvider serviceProvider)
    {
        serviceProvider.GetRequiredService<IMapper>()
            .ConfigurationProvider
            .AssertConfigurationIsValid();
    }
}