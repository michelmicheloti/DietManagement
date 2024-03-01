using Microsoft.EntityFrameworkCore;

namespace DietManagement.Tests
{
    public class FoodContextTests
    {
        [Fact]
        public void Can_Create_FoodContext()
        {
            // Arrange & Act
            var options = new DbContextOptionsBuilder<FoodContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Assert
            using (var context = new FoodContext(options))
            {
                Assert.NotNull(context);
            }
        }
    }
}
