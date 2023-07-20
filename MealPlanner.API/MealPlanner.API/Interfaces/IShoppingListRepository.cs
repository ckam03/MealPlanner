using MealPlanner.API.Entities;

namespace MealPlanner.API.Interfaces
{
    public interface IShoppingListRepository
    {
        Task<List<ShoppingList>> GetAllAsync();
        Task<ShoppingList?> GetByIdAsync(Guid id);
        void Add(ShoppingList item);
        void Delete(ShoppingList item);
    }
}