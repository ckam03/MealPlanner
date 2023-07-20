using MealPlanner.API.Data;
using MealPlanner.API.Entities;

namespace MealPlanner.API;

public class RecipeRepository : IRecipeRepository
{
    private readonly MealDbContext _dbContext;
    public RecipeRepository(MealDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Recipe recipe) 
    {
        _dbContext.Add(recipe);
    }
}
