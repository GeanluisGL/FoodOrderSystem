using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace FoodOrderSystem.Models
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Pizza", Description = "Cheese, Meat, Corn, any ingredient you want" },
                    new Category { Id = 2, Name =  "Burguers", Description = "Juicy burgers"},
                    new Category { Id = 3, Name = "Drinks", Description = "Refreshing beverages" }

                );

            modelBuilder.Entity<FoodItem>().HasData(
               
                new FoodItem { Id = 1, Name = "Cheese Pizza", Description = "Classic tomato and Cheese", Price = 12.99m, CategoryId = 1, ImageUrl = ""},
                new FoodItem { Id = 2, Name = "Pepperoni Pizza", Description = "Spicy pepperoni with cheese", Price = 15.99m, CategoryId = 1, ImageUrl = "" },
                new FoodItem { Id = 3, Name = "Cheeseburger", Description = "Beef Patty with cheese", Price = 9.50m, CategoryId = 2, ImageUrl = ""}
                );

            modelBuilder.Entity<User>().HasData(
                new User{
                   Id = 01,
                   Username = "AoA",
                   Email = "admin@foodorder.com",
                   Password = "admin123",
                   FullName = "Administrator of Administrators",
                   Address = "Admin Office",
                   Phone = "(123) 456- 7890",
                   IsAdmin = true,
                }
                );

        }
    }
}
