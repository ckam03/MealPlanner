namespace MealPlanner.API.Entities;

public class ShoppingList
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<ShoppingListItem> ListItems { get; set; } = null!;
}