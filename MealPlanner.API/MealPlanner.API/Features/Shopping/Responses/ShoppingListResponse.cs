using MealPlanner.API.Entities;

namespace MealPlanner.API.Features.Shopping.Responses;

public record ShoppingListResponse(Guid Id, string Name, ICollection<ShoppingListItem> ShoppingListItems);
