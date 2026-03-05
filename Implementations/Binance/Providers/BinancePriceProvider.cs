using System.Globalization;
using System.Text.Json;
using Core.Abstractions;
using exchange.platform.clients.abstractions.Providers;

namespace exchange.platform.binance.Providers;

public class BinancePriceProvider(HttpClient client) : IExchangePriceProvider
{
    public string ExchangeName => "binance";
    
    public async Task<decimal> GetPriceAsync(string symbol, CancellationToken ct)
    {
        Console.WriteLine("BaseAddress: " + client.BaseAddress);
        var response = await client.GetStringAsync($"/api/v3/ticker/price?symbol={symbol}", ct);

        var doc = JsonDocument.Parse(response);
        var priceString = doc.RootElement.GetProperty("price").GetString();
        decimal price = 0;
        
        if (priceString != null)
        {
            price = decimal.Parse(priceString, NumberStyles.Any, CultureInfo.InvariantCulture);
        }
        
        return price;
    }
}