namespace exchange.platform.Models;

public sealed record ExchangePriceDto
{
    public required decimal Price { get; init; }
}
