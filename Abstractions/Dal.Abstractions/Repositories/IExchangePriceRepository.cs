using exchange.platform.dal.abstractions.Models;

namespace exchange.platform.dal.abstractions.Repositories;

public interface IExchangePriceRepository
{
    // пока не использую, контракт на будущее
    Task<ExchangePriceRepositoryModel?> GetExchangePriceAsync(
        string pairName,
        string exchangeName,
        CancellationToken ct);
}