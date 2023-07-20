using MealPlanner.API.Entities;

namespace MealPlanner.API;

public interface IRecipeRepository
{
    void Add(Recipe recipe);
}
