namespace MealPlanner.API.Entities;

public class MealPlan
{
    public Guid Id { get; set; }
    public List<Meal> Meals { get; set; } = new();
}