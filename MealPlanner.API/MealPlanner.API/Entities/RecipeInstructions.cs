namespace MealPlanner.API.Entities;

public class RecipeInstructions
{
    public Guid Id { get; set; }
    public List<string> Instructions { get; set; } = new();
    public Guid RecipeId { get; set; }
}
