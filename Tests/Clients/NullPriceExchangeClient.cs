using exchange.platform.clients.abstractions.Models;
using exchange.platform.clients.abstractions.Providers;

namespace Tests.Clients;

internal sealed class NullPriceExchangeClient : IPriceExchangeClient
{
    public Task<PriceExchangeModel?> GetPriceQueryAsync(GetPriceExchangeModel getPriceModel, CancellationToken ct)
    {
        return Task.FromResult<PriceExchangeModel?>(null);
    }
}

