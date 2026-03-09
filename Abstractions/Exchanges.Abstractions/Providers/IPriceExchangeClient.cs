using exchange.platform.clients.abstractions.Models;

namespace exchange.platform.clients.abstractions.Providers;

public interface IPriceExchangeClient
{
    Task<decimal?> GetPriceQueryAsync(GetPriceExchangeModel symbol, CancellationToken ct);
}