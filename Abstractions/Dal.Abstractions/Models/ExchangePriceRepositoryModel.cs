namespace exchange.platform.dal.abstractions.Models;

public sealed record ExchangePriceRepositoryModel
{
    public required Guid Id { get; init; }
    public required string PairName { get; init; }
    public required string ExchangeName { get; init; }
    public required decimal Price { get; init; }
    public required DateTime RetrievedAtUtc { get; init; }
}