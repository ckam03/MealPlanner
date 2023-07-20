using MealPlanner.API.Entities;
using MealPlanner.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.API.Data.Repositories;

public class ShoppingListRepository : IShoppingListRepository
{
    private readonly MealDbContext _context;

    public ShoppingListRepository(MealDbContext context)
    {
        _context = context;
    }

    public async Task<ShoppingList?> GetByIdAsync(Guid id)
    {
        return await _context.Lists.FindAsync(id);
    }

    public async Task<List<ShoppingList>> GetAllAsync()
    {
        return await _context.Lists.ToListAsync();
    }

    public void Add(ShoppingList item)
    {
        _context.Lists.Add(item);
    }

    public void Update(ShoppingList item) 
    {
        _context.Lists.Update(item);
    }

    public void Delete(ShoppingList item)
    {
        _context.Lists.Remove(item);
    }
}
