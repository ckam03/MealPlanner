using MealPlanner.API.Features.Recipes.Services;

namespace MealPlanner.RecipeParser;

public class UnitTest1
{
    private readonly RecipeParserService _recipeParserService;

    public UnitTest1(RecipeParserService recipeParserService)
    {
        _recipeParserService = recipeParserService;
    }

    [Fact]
    public void Test1()
    {
        _recipeParserService.GetRecipe("url");
    }
}