using exchange.platform.clients.abstractions.Providers;
using exchange.platform.Configurations;
using exchange.platform.core;
using Microsoft.Extensions.DependencyInjection;
using Tests.Clients;

namespace Tests.Fixtures;

public sealed class CoreWithTestClientFixture : IDisposable
{
    public IServiceProvider ServiceProvider { get; }

    public CoreWithTestClientFixture()
    {
        var services = new ServiceCollection();
        
        services.AddLogging();
        
        services.ConfigureAutoMapper();
        
        services.ConfigureCoreServices();
        
        services.AddKeyedTransient<IPriceExchangeClient, TestPriceExchangeClient>("TestExchangeClient");
        
        ServiceProvider = services.BuildServiceProvider();

    }
    
    public void Dispose()
    {
        (ServiceProvider as IDisposable)?.Dispose();
    }
}