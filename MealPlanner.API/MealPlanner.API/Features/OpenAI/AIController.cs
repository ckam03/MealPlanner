using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.API.Features.OpenAI;

[Route("api/[controller]")]
[ApiController]
public class AIController : ControllerBase
{
    private readonly IOpenAIService _openAIService;

    public AIController(IOpenAIService openAIService)
    {   
        _openAIService = openAIService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var recipe = await _openAIService.GetRecipe();
        return Ok(recipe);
    }
}
