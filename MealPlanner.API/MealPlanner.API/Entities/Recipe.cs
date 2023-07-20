namespace MealPlanner.API.Entities;

public class Recipe
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Ingredient> Ingredients { get; set; } = null!;
    public List<string> Instructions { get; set; } = new();
}