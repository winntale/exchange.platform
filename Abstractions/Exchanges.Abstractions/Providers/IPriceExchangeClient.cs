using exchange.platform.clients.abstractions.Models;

namespace exchange.platform.clients.abstractions.Providers;

public interface IPriceExchangeClient
{
    Task<PriceExchangeModel?> GetPriceQueryAsync(GetPriceExchangeModel getPriceModel, CancellationToken ct);
}