using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json;
using exchange.platform.clients.abstractions.Models;
using exchange.platform.clients.abstractions.Providers;

namespace exchange.platform.binance.Providers;

internal sealed class BinancePriceProvider(HttpClient client) : IExchangePriceProvider
{
    public string ExchangeName => "binance";
    
    public async Task<decimal?> GetPriceAsync(string symbol, CancellationToken ct)
    {
        var response = await client.GetAsync($"/api/v3/ticker/price?symbol={symbol}", ct);
        response.EnsureSuccessStatusCode();
        
        var binanceModel = await response.Content.ReadFromJsonAsync<ExchangePriceModel>(cancellationToken: ct);

        var price = binanceModel?.Price;
        
        return price;
    }
}