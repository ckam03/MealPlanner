using MealPlanner.API.Entities;
using MealPlanner.API.Interfaces;

namespace MealPlanner.API.Data.Repositories;

public class ShoppingListItemRepository : IShoppingListItemRepository
{
    private readonly MealDbContext _context;

    public ShoppingListItemRepository(MealDbContext context)
    {
        _context = context;
    }

    public async Task<ShoppingListItem> GetById(Guid id)
    {
        return await _context.ListItems.FindAsync(id);
    }

    public void Add(ShoppingListItem item)
    {
        _context.ListItems.Add(item);
    }

    public void Update(ShoppingListItem item)
    {
        _context.ListItems.Update(item);
    }

    public void Remove(ShoppingListItem item)
    {
        _context.ListItems.Remove(item);
    }
}