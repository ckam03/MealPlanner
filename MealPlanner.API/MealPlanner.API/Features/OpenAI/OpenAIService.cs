using Azure;
using Azure.AI.OpenAI;

namespace MealPlanner.API.Features.OpenAI;

public class OpenAIService : IOpenAIService
{
    private readonly string? _apiKey;
    private readonly OpenAIClient _openAIClient;

    public OpenAIService(IConfiguration configuration)
    {
        _apiKey = configuration["OpenAI:ApiKey"];
        _openAIClient = new(_apiKey);
    }

    public async Task<Response<Completions>> GetRecipe()
    {
        Response<Completions> response = await _openAIClient.GetCompletionsAsync(
                "text-davinci-003", // assumes a matching model deployment or model name
                "Hello, world!");

        return response;
    }
}
