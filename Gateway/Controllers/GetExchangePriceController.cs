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
    public async Task<ActionResult<ExchangePriceDto>> Get(
        [FromServices] IGetExchangePriceOperation process,
        [FromQuery] GetExchangePriceDto requestModel,
        CancellationToken ct)
    {
        var operationModel = mapper.Map<GetExchangePriceOperationModel>(requestModel);

        var result = await process.GetExchangePriceAsync(operationModel, ct);

        if (result.IsFailure)
        {
            return result.Error.ToResponse();
        }

        var value = mapper.Map<ExchangePriceDto>(result.Value);
        return Ok(value);

    }
}