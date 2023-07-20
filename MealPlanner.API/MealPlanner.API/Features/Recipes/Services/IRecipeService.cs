using MealPlanner.API.Shared;

namespace MealPlanner.API.Features.Recipes.Services;

public interface IRecipeService
{
    Task<Result<RecipeResponse>> GetRecipesAsync(string ingredient);
    Task<Result<RecipeResponse>> GetRecipesByPantryAsync();
}