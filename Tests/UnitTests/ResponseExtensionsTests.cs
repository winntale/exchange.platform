using Core.Abstractions;
using exchange.platform.Extensions;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Tests.UnitTests;

public sealed class ResponseExtensionsTests
{
    [Theory]
    [InlineData(ErrorType.Validation, 400)]
    [InlineData(ErrorType.NotFound, 404)]
    [InlineData(ErrorType.Conflict, 409)]
    [InlineData(ErrorType.Failure, 500)]
    [InlineData(ErrorType.None, 500)]
    public void ToResponse_MapsErrorTypeToCorrectStatusCode(ErrorType errorType, int expectedStatusCode)
    {
        // Arrange
        var error = errorType switch
        {
            ErrorType.Validation => Error.Validation("validation"),
            ErrorType.NotFound   => Error.NotFound("not found"),
            ErrorType.Conflict   => Error.Conflict("conflict"),
            ErrorType.Failure    => Error.Failure("failure"),
            _                    => Error.Failure("none")
        };

        // Act
        var result = error.ToResponse();

        // Assert
        var objectResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(expectedStatusCode, objectResult.StatusCode);
    }
}

