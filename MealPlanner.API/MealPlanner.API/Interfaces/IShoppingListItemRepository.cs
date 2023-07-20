using MealPlanner.API.Entities;

namespace MealPlanner.API.Interfaces
{
    public interface IShoppingListItemRepository
    {
        void Add(ShoppingListItem item);
        void Remove(ShoppingListItem item);
        Task<ShoppingListItem> GetById(Guid id);
        void Update(ShoppingListItem item);
    }
}