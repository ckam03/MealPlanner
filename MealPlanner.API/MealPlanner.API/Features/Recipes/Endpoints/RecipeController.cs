using MealPlanner.API.Features.Recipes.Commands;
using MealPlanner.API.Features.Recipes.Services;
using MealPlanner.API.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.API.Features.Recipes.Endpoints;

[Route("api/[controller]")]
[ApiController]
public class RecipeController : ControllerBase
{
    private readonly IRecipeService _recipeService;
    private readonly IRecipeParserService _recipeParserService;
    private readonly IMediator _mediator;

    public RecipeController(IRecipeService recipeService, IRecipeParserService recipeParserService, IMediator mediator)
    {
        _recipeService = recipeService;
        _recipeParserService = recipeParserService;
        _mediator = mediator;
    }

    [HttpGet("{ingredient}")]
    public async Task<ActionResult<RecipeResponse>> GetAsync(string ingredient)
    {
        Result<RecipeResponse> recipes = await _recipeService.GetRecipesAsync(ingredient);
        if (!recipes.IsSuccess)
        {
            return NotFound(recipes.Error);
        }
        return Ok(recipes.Value);
    }

    [HttpGet("/api/recipe/pantry")]
    public async Task<ActionResult<RecipeResponse>> GetByPantryAsync()
    {
        Result<RecipeResponse> recipes = await _recipeService.GetRecipesByPantryAsync();

        if (!recipes.IsSuccess)
        {
            return NotFound();
        }

        return Ok(recipes);
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync(CreateRecipeRequest request)
    {
        await _mediator.Send(new CreateRecipeCommand(request));
        return Ok();
    }

    [HttpPost("/api/recipe/url")]
    public async Task<ActionResult> ScrapeRecipeAsync([FromBody] string url)
    {
       var recipe = await _recipeParserService.ParseUrl(url);
       return Ok(recipe);
    }
}
