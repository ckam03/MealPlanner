using System.ComponentModel.DataAnnotations;

namespace MealPlanner.API.Entities;

public class Ingredient
{
    [Key]
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int Amount { get; set; } = 0;
    public string Unit { get; set; } = string.Empty;
}
