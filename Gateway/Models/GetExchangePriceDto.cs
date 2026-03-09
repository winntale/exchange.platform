namespace exchange.platform.Models;

public sealed record GetExchangePriceDto
{
    public required string PairName { get; init; }
    public required string ExchangeName { get; init; }
}