namespace exchange.platform.clients.abstractions.Providers;

public interface IExchangePriceProvider
{
    string ExchangeName { get; }
    Task<decimal> GetPriceAsync(string symbol, CancellationToken ct);
}