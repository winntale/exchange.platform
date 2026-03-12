using exchange.platform.clients.abstractions.Models;
using exchange.platform.clients.abstractions.Providers;

namespace Tests.Clients;

internal sealed class TestPriceExchangeClient : IPriceExchangeClient
{
    public Task<PriceExchangeModel?> GetPriceQueryAsync(GetPriceExchangeModel getPriceModel, CancellationToken ct)
    {
        return Task.FromResult(new PriceExchangeModel
        {
            Symbol = getPriceModel.Symbol,
            Price  = 1m
        });
    }
}