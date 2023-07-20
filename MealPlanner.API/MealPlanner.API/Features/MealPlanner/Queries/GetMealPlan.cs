using MealPlanner.API.Data;
using MealPlanner.API.Entities;
using MediatR;

namespace MealPlanner.API.Features.MealPlanner.Queries;

public class GetMealPlan
{
    public record Query() : IRequest<MealPlan>;

    // public class Handler : IRequestHandler<Query, WeeklyMealPlan>
    // {
    //     private readonly MealDbContext _context;

    //     public Handler(MealDbContext context)
    //     {
    //         _context = context;
    //     }

    //     // public async Task<WeeklyMealPlan> Handle(Query request, CancellationToken cancellationToken)
    //     // {
            
    //     // }
    // }
}