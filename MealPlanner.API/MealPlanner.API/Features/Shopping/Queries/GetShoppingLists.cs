using MealPlanner.API.Data;
using MealPlanner.API.Features.Shopping.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.API.Features.Shopping.Queries;

public class GetShoppingLists
{
    public record Query() : IRequest<ICollection<ShoppingListResponse>>;

    public class Handler : IRequestHandler<Query, ICollection<ShoppingListResponse>>
    {
        private readonly MealDbContext _context;

        public Handler(MealDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<ShoppingListResponse>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _context.Lists
                .Select(shoppingList => new ShoppingListResponse(shoppingList.Id, shoppingList.Name, shoppingList.ListItems))
                .ToListAsync(cancellationToken);
        }
    }
}