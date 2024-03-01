using Microsoft.EntityFrameworkCore;

namespace DietManagement.Tests.Helpers;
public static class DbContextHelper
{
    public static FoodContext CreateInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<FoodContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        return new FoodContext(options);
    }
}
