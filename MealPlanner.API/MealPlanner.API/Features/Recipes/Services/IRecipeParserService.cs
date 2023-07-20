using MealPlanner.API.Entities;

namespace MealPlanner.API.Features.Recipes;

public interface IRecipeParserService
{
    Task<Recipe> ParseUrl(string url);
}
