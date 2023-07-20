using MealPlanner.API.Data;
using MealPlanner.API.Entities;
using MediatR;

namespace MealPlanner.API.Features.MealPlanner.Commands;

public class CreateMealPlan
{
    public record Command(MealPlan MealPlan) : IRequest<MealPlan>;

    public class Handler : IRequestHandler<Command, MealPlan>
    {
        private readonly MealDbContext _context;

        public Handler(MealDbContext context)
        {
            _context = context;
        }

        public async Task<MealPlan> Handle(Command request, CancellationToken cancellationToken)
        {
            await _context.MealPlans.AddAsync(request.MealPlan, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return request.MealPlan;
        }
    }
}