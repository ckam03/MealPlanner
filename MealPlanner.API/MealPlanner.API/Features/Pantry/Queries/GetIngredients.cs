using MealPlanner.API.Data;
using MealPlanner.API.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.API.Features.Pantry.Queries;

public class GetIngredients
{
    public record Query() : IRequest<ICollection<Ingredient>>;
    
    public class Handler : IRequestHandler<Query, ICollection<Ingredient>>
    {
        private readonly MealDbContext _context;

        public Handler(MealDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Ingredient>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _context.Pantry.ToListAsync(cancellationToken);
        }
    }
}