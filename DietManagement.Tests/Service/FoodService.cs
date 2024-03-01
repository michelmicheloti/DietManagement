using DietManagement.Tests.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DietManagement.Tests.Services;

public class FoodServiceTests
{
    [Fact]
    public async Task CreateFoodAsync_WithValidParameters_ShouldCreateFoodInDatabase()
    {
        // Arrange
        using var context = DbContextHelper.CreateInMemoryContext();
        var service = new FoodService(context);
        var name = "Apple";
        var foodGroup = "Fruits";
        var proteins = 0.3;
        var carbohydrates = 25.0;
        var fats = 0.2;
        var calories = 95.0;

        // Act
        var result = await service.CreateFoodAsync(name, foodGroup, proteins, carbohydrates, fats, calories);

        // Assert
        Assert.True(result.Success);
        Assert.NotNull(result.Data);
        Assert.Empty(result.Errors);
        Assert.Equal(name, result.Data.Name);
        Assert.Equal(foodGroup, result.Data.FoodGroup);


        var foodInDatabase = await context.Foods.FirstOrDefaultAsync(f => f.Name == name);
        Assert.NotNull(foodInDatabase);
        Assert.Equal(name, foodInDatabase.Name);
        Assert.Equal(foodGroup, foodInDatabase.FoodGroup);
    }

    [Theory]
    [InlineData("", "Fruits", 0.3, 25.0, 0.2, 95.0)]
    [InlineData("Apple", "", 0.3, 25.0, 0.2, 95.0)]
    [InlineData("Apple", "Fruits", -0.3, 25.0, 0.2, 95.0)]
    [InlineData("Apple", "Fruits", 0.3, -25.0, 0.2, 95.0)]
    [InlineData("Apple", "Fruits", 0.3, 25.0, -0.2, 95.0)]
    [InlineData("Apple", "Fruits", 0.3, 25.0, 0.2, -95.0)]
    public async Task CreateFoodAsync_WithInvalidParameters_ShouldReturnFailureAndErrors(
            string name,
            string foodGroup,
            double proteins,
            double carbohydrates,
            double fats,
            double calories)
    {
        // Arrange
        using var context = DbContextHelper.CreateInMemoryContext();
        var service = new FoodService(context);

        // Act
        Result<Food> result = await service.CreateFoodAsync(name, foodGroup, proteins, carbohydrates, fats, calories);

        // Assert
        Assert.False(result.Success);
        Assert.NotNull(result.Errors);
        Assert.Null(result.Data);
    }
}

