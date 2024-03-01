namespace DietManagement;

public interface IFoodService
{
    Task<Result<Food>> CreateFoodAsync(string name, string foodGroup, double proteins, double carbohydrates, double fats, double calories);
}

