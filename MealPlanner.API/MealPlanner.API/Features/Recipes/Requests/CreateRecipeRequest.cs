using MealPlanner.API.Entities;

namespace MealPlanner.API;

public record CreateRecipeRequest(string Name, 
                                  ICollection<Ingredient> Ingredients, 
                                  List<string> Instructions);
