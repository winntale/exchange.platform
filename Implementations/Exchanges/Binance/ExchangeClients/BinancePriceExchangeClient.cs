using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json;
using exchange.platform.clients.abstractions.Models;
using exchange.platform.clients.abstractions.Providers;

namespace exchange.platform.binance.ExchangeClients;

internal sealed class BinancePriceExchangeClient(IHttpClientFactory httpClientFactory) : IPriceExchangeClient
{
    public async Task<PriceExchangeModel?> GetPriceQueryAsync(GetPriceExchangeModel getPriceModel, CancellationToken ct)
    {
        var client = httpClientFactory.CreateClient("Binance");
        
        var response = await client.GetAsync($"/api/v3/ticker/price?symbol={getPriceModel.Symbol}", ct);
        response.EnsureSuccessStatusCode();
        
        var binanceModel = await response.Content.ReadFromJsonAsync<PriceExchangeModel>(cancellationToken: ct);
        
        return binanceModel;
    }
}