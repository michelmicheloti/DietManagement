namespace DietManagement;
public class FoodService : IFoodService
{
    private readonly FoodContext _context;

    public FoodService(FoodContext context)
    {
        _context = context;
    }

    public async Task<Result<Food>> CreateFoodAsync(string name, string foodGroup, double proteins, double carbohydrates, double fats, double calories)
    {
        var (success, errors, food) = Food.Create(name, foodGroup, proteins, carbohydrates, fats, calories);

        if (!success)
        {
            return Result<Food>.Fail(errors);
        }

        _context.Foods.Add(food);
        await _context.SaveChangesAsync();

        return Result<Food>.Ok(food);
    }
}

