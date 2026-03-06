namespace exchange.platform.Models;

public sealed record ExchangePriceDto
{
    public required Guid Id { get; init; }
    public required string PairName { get; init; }
    public required string ExchangeName { get; init; }
    public required decimal Price { get; init; }
}
