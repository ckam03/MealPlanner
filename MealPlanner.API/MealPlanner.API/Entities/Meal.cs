namespace MealPlanner.API.Entities;

public class Meal
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
    public Recipe Recipe { get; set; } = null!;
}