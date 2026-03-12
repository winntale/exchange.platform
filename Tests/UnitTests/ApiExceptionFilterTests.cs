using System.Net;
using exchange.platform.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Tests.UnitTests;

public sealed class ApiExceptionFilterTests
{
    [Fact]
    public void OnException_WhenApiException_SetsStatusCodeFromException()
    {
        // Arrange
        var logger = new Mock<ILogger<ApiExceptionFilter>>();
        var filter = new ApiExceptionFilter(logger.Object);

        var httpContext = new DefaultHttpContext();
        var actionContext = new ActionContext
        {
            HttpContext = httpContext
        };

        var exceptionContext = new ExceptionContext(actionContext, []);

        var apiException = new ApiException("error", StatusCodes.Status418ImATeapot, "resp", new Dictionary<string, IEnumerable<string>>(), new Exception("inner"));
        exceptionContext.Exception = apiException;

        // Act
        filter.OnException(exceptionContext);

        // Assert
        Assert.Equal(StatusCodes.Status418ImATeapot, httpContext.Response.StatusCode);
        Assert.IsType<JsonResult>(exceptionContext.Result);
    }

    [Fact]
    public void OnException_WhenGenericException_MapsToInternalServerError()
    {
        // Arrange
        var logger = new Mock<ILogger<ApiExceptionFilter>>();
        var filter = new ApiExceptionFilter(logger.Object);

        var httpContext = new DefaultHttpContext();
        var actionContext = new ActionContext
        {
            HttpContext = httpContext
        };

        var exceptionContext = new ExceptionContext(actionContext, []);

        exceptionContext.Exception = new Exception("error");

        // Act
        filter.OnException(exceptionContext);

        // Assert
        Assert.Equal((int)HttpStatusCode.InternalServerError, httpContext.Response.StatusCode);
        Assert.IsType<JsonResult>(exceptionContext.Result);
    }
}

