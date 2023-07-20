using Azure;
using Azure.AI.OpenAI;

namespace MealPlanner.API.Features.OpenAI;

public interface IOpenAIService
{
    Task <Response<Completions>> GetRecipe();
}