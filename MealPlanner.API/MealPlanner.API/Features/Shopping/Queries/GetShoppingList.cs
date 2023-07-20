using MealPlanner.API.Data;
using MealPlanner.API.Features.Shopping.Responses;
using MealPlanner.API.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MealPlanner.API.Features.Shopping.Queries;

public class GetShoppingList
{
    public record Query(Guid Id) : IRequest<Result<ShoppingListResponse>>;

    public class Handler : IRequestHandler<Query, Result<ShoppingListResponse>>
    {
        private readonly MealDbContext _dbContext;

        public Handler(MealDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<ShoppingListResponse>> Handle(Query request, CancellationToken cancellationToken)
        {
            var shoppingList = await _dbContext.Lists
                .Where(x => x.Id == request.Id)
                .Select(y => new ShoppingListResponse(y.Id, y.Name, y.ListItems))
                .FirstOrDefaultAsync(cancellationToken);

            if (shoppingList is null)
            {
                return Result<ShoppingListResponse>.Failure("Shopping List does not exist");
            }

            return Result<ShoppingListResponse>.Success(shoppingList);

        }
    }
}