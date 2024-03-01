using Microsoft.EntityFrameworkCore;

namespace DietManagement
{
    public class FoodContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }

        public FoodContext(DbContextOptions<FoodContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=food.db");
            }
        }
    }
}
