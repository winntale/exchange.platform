using exchange.platform.clients.abstractions.Providers;

namespace exchange.platform.binance.Providers;

public class BinancePriceProvider(HttpClient client) : IExchangePriceProvider
{
    public string ExchangeName => "binance";
    
    public async Task<decimal> GetPriceAsync(string symbol, CancellationToken ct)
    {
        var response = await client.GetStringAsync($"/api/some/link/price?symbol={symbol}", ct);

        return decimal.Parse(response);
    }
}