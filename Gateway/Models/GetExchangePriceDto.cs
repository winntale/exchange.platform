namespace exchange.platform.Models;

public sealed record GetExchangePriceDto
{
    public required Guid Id { get; init; }
    public required string PairName { get; init; }
    public required string ExchangeName { get; init; }
}