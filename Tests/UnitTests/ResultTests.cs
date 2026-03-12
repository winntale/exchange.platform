using Core.Abstractions;
using Xunit;

namespace Tests.UnitTests;

public sealed class ResultTests
{
    [Fact]
    public void Success_Factory_CreatesSuccessfulResult()
    {
        // Act
        var result = Result.Success();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
        Assert.Equal(Error.None, result.Error);
    }

    [Fact]
    public void Implicit_FromError_CreatesFailureResult()
    {
        // Act
        Result result = Error.Validation("validation error");

        // Assert
        Assert.False(result.IsSuccess);
        Assert.True(result.IsFailure);
        Assert.Equal(ErrorType.Validation, result.Error.Type);
        Assert.Equal("validation error", result.Error.Message);
    }

    [Fact]
    public void GenericResult_Success_AllowsAccessToValue()
    {
        // Act
        Result<string> result = "value";

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal("value", result.Value);
    }

    [Fact]
    public void GenericResult_Failure_ThrowsOnValueAccess()
    {
        // Arrange
        Result<string> result = Error.Failure("failed");

        // Act & Assert
        Assert.False(result.IsSuccess);
        Assert.Throws<InvalidOperationException>(() => _ = result.Value);
    }
}

