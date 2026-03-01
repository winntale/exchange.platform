namespace exchange.platform.Models;

public sealed record PriceDto
{
    public required string PairName { get; init; }
    public required string ExchangeName { get; init; }
}