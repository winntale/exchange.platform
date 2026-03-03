using AutoMapper;
using exchange.platform.Models;
using Core.Abstractions.Operations.Price;
using Core.Abstractions.Operations.Price.Queries;
using exchange.platform.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace exchange.platform.Controllers;

[ApiController]
[Route("api/price")]
public sealed class GetExchangePriceController(IMapper mapper)
    : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<decimal>> Get(
        [FromServices] IGetExchangePriceOperation process,
        [FromQuery] PriceDto requestModel,
        CancellationToken ct)
    {
        var queryModel = mapper.Map<GetExchangePriceQuery>(requestModel);

        var result = await process.GetPriceAsync(queryModel, ct);

        if (result.IsSuccess)
            return Ok(result.Value);

        return result.Error.ToResponse();
    }
}