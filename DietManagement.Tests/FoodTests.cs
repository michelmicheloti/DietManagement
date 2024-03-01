namespace DietManagement.Tests;
public class FoodTests
{
    [Fact]
    public void CreateFood_WithValidParameters_ShouldReturnSuccessAndFoodObject()
    {
        // Arrange
        string name = "Apple";
        string foodGroup = "Fruits";
        double proteins = 0.3;
        double carbohydrates = 25.0;
        double fats = 0.2;
        double calories = 95.0;

        // Act
        var (success, errors, food) = Food.Create(name, foodGroup, proteins, carbohydrates, fats, calories);

        // Assert
        Assert.True(success);
        Assert.Empty(errors);
        Assert.NotNull(food);
        Assert.Equal(name, food.Name);
        Assert.Equal(foodGroup, food.FoodGroup);
        Assert.Equal(proteins, food.Proteins);
        Assert.Equal(carbohydrates, food.Carbohydrates);
        Assert.Equal(fats, food.Fats);
        Assert.Equal(calories, food.Calories);
    }

    [Theory]
    [InlineData("", "Fruits", 0.3, 25.0, 0.2, 95.0)]
    [InlineData("Apple", "", 0.3, 25.0, 0.2, 95.0)]
    [InlineData("Apple", "Fruits", -0.3, 25.0, 0.2, 95.0)]
    [InlineData("Apple", "Fruits", 0.3, -25.0, 0.2, 95.0)]
    [InlineData("Apple", "Fruits", 0.3, 25.0, -0.2, 95.0)]
    [InlineData("Apple", "Fruits", 0.3, 25.0, 0.2, -95.0)]
    public void CreateFood_WithInvalidParameters_ShouldReturnFailureAndErrors(
        string name,
        string foodGroup,
        double proteins,
        double carbohydrates,
        double fats,
        double calories)
    {
        // Act
        var (success, errors, food) = Food.Create(name, foodGroup, proteins, carbohydrates, fats, calories);

        // Assert
        Assert.False(success);
        Assert.NotEmpty(errors);
        Assert.Null(food);
    }
}

