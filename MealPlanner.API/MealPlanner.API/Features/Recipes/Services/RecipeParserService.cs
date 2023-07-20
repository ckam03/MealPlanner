using MealPlanner.API.Entities;
using MealPlanner.Scraper;

namespace MealPlanner.API.Features.Recipes.Services;


public class RecipeParserService : IRecipeParserService
{
    private readonly IWebScraper _scraper;
    private readonly ILogger<RecipeParserService> _logger;

    public RecipeParserService(ILogger<RecipeParserService> logger, IWebScraper scraper)
    {
        _scraper = scraper;
        _logger = logger;
    }

    public async Task<Recipe> ParseUrl(string url)
    {
        string message = _scraper.Print(url);
        _logger.LogInformation(message);
        return new Recipe();
    }
}
