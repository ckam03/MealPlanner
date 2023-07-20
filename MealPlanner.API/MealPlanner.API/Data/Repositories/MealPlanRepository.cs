using MealPlanner.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.API.Data.Repositories;

public class MealPlanRepository
{
    private readonly MealDbContext _context;
    
    public MealPlanRepository(MealDbContext context)
    {
        _context = context;
    }

    public async Task<List<MealPlan>> GetMealPlanAsync()
    {
        return await _context.MealPlans.ToListAsync();
    }
}