using MealPlanner.API.Data;
using MealPlanner.API.Shared;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.API.Features.Recipes.Services;

public class RecipeService : IRecipeService
{
    private readonly MealDbContext _dbContext;
    private readonly HttpClient _httpClient;
    private readonly string? _apiKey;
    private readonly string? _appId;
    private const string Url = "/api/recipes/v2?type=public&q={0}&app_id={1}&app_key={2}&random=true";

    public RecipeService(MealDbContext dbContext, HttpClient httpClient, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://api.edamam.com");
        _apiKey = configuration["Edamam:ServiceApiKey"];
        _appId = configuration["Edamam:ServiceAppId"];
    }

    public async Task<Result<RecipeResponse>> GetRecipesAsync(string ingredient)
    {
        var result = await _httpClient.GetFromJsonAsync<RecipeResponse>(string.Format(Url, ingredient, _appId, _apiKey));
        return result is null ? Result<RecipeResponse>.Failure("No recipes found") : Result<RecipeResponse>.Success(result);
    }

    public async Task<Result<RecipeResponse>> GetRecipesByPantryAsync()
    {
        //get a list of recipe based on pantry ingredients
        List<string> ingredients = await _dbContext.Pantry
            .Select(ingredient => ingredient.Name)
            .ToListAsync();

        var recipeUrl = string.Join(",", ingredients).Replace(",", "%20");
        var result = await _httpClient.GetFromJsonAsync<RecipeResponse>(string.Format(Url, ingredients, _appId, _apiKey));

        return result is null ? Result<RecipeResponse>.Failure("No recipes found") : Result<RecipeResponse>.Success(result);
    }
}