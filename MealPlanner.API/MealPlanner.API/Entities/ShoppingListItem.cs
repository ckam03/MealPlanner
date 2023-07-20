using System.ComponentModel.DataAnnotations;

namespace MealPlanner.API.Entities;

public class ShoppingListItem
{
    [Key]
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int Amount { get; set; } = 0;
    public string Unit { get; init; } = string.Empty;
    public Guid ShoppingListId { get; set; }
}