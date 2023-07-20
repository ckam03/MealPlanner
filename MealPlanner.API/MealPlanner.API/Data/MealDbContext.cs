using MealPlanner.API.Entities;
using MealPlanner.API.Features.Authentication;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.API.Data;

public class MealDbContext : DbContext
{
    public MealDbContext(DbContextOptions<MealDbContext> options) : base(options)
    {
    }

    public DbSet<Ingredient> Pantry => Set<Ingredient>();
    public DbSet<ShoppingList> Lists => Set<ShoppingList>();
    public DbSet<ShoppingListItem> ListItems => Set<ShoppingListItem>();
    public DbSet<Recipe> Recipes => Set<Recipe>();
    public DbSet<RecipeInstructions> RecipeInstructions => Set<RecipeInstructions>();
    public DbSet<MealPlan> MealPlans => Set<MealPlan>();
    public DbSet<Meal> Meals => Set<Meal>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>()
            .HasData (
                new Recipe { Id = Guid.NewGuid(), Name = "Chickpea Pasta" },
                new Recipe { Id = Guid.NewGuid(), Name = "Chickpea Salad" },
                new Recipe { Id = Guid.NewGuid(), Name = "Chicken Salad" }
            );
    }
}