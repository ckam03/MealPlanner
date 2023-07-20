using MealPlanner.API.Interfaces;

namespace MealPlanner.API.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly MealDbContext _context;

    public UnitOfWork(MealDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync(CancellationToken cancellationToken) => await _context.SaveChangesAsync(cancellationToken);
}
