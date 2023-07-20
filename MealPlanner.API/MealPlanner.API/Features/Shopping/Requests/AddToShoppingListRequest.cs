namespace MealPlanner.API.Features.Shopping.Requests;

public record AddToShoppingListRequest(string Name,
                                       int Amount,
                                       string Unit,
                                       Guid ShoppingListId);