namespace DietManagement.Tests.Helpers;

public class ResultTests
{
    [Fact]
    public void Ok_WithValidData_ShouldReturnSuccessAndData()
    {
        // Arrange
        var data = new List<string> { "apple", "banana", "orange" };

        // Act
        var result = Result<List<string>>.Ok(data);

        // Assert
        Assert.True(result.Success);
        Assert.Equal(data, result.Data);
        Assert.Empty(result.Errors);
    }

    [Fact]
    public void Fail_WithErrors_ShouldReturnFailureAndErrors()
    {
        // Arrange
        var errors = new List<string> { "Error 1", "Error 2", "Error 3" };

        // Act
        var result = Result<object>.Fail(errors);

        // Assert
        Assert.False(result.Success);
        Assert.Equal(errors, result.Errors);
        Assert.Null(result.Data);
    }
}

