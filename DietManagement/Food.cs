namespace DietManagement;

public class Food
{
    private Food() { }

    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string FoodGroup { get; private set; } = string.Empty;
    public double Proteins { get; private set; }
    public double Carbohydrates { get; private set; }
    public double Fats { get; private set; }
    public double Calories { get; private set; }

    public static (bool success, List<string> errors, Food food) Create(
        string name,
        string foodGroup,
        double proteins,
        double carbohydrates,
        double fats,
        double calories)
    {
        var validationErrors = Validate(name, foodGroup, proteins, carbohydrates, fats, calories);

        if (validationErrors.Count > 0)
        {
            return (false, validationErrors, null!);
        }

        var food = new Food
        {
            Name = name,
            FoodGroup = foodGroup,
            Proteins = proteins,
            Carbohydrates = carbohydrates,
            Fats = fats,
            Calories = calories
        };

        return (true, new List<string>(), food);
    }

    private static List<string> Validate(
        string name,
        string foodGroup,
        double proteins,
        double carbohydrates,
        double fats,
        double calories)
    {
        var errors = new List<string>();

        if (string.IsNullOrEmpty(name))
            errors.Add("Name cannot be null or empty.");

        if (string.IsNullOrEmpty(foodGroup))
            errors.Add("FoodGroup cannot be null or empty.");

        if (proteins < 0)
            errors.Add("Proteins must be a non-negative value.");

        if (carbohydrates < 0)
            errors.Add("Carbohydrates must be a non-negative value.");

        if (fats < 0)
            errors.Add("Fats must be a non-negative value.");

        if (calories < 0)
            errors.Add("Calories must be a non-negative value.");

        return errors;
    }
}