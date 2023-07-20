using MealPlanner.API.Entities;
using MealPlanner.API.Interfaces;
using MealPlanner.API.Shared;
using MediatR;

namespace MealPlanner.API.Features.Shopping.Commands;

public static class UpdateShoppingList
{
    public record Command(string Name, Guid Id) : IRequest<Result<ShoppingList>>;

    public class Handler : IRequestHandler<Command, Result<ShoppingList>>
    {
        private readonly IShoppingListRepository _shoppingListRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork, IShoppingListRepository shoppingListRepository)
        {
            _unitOfWork = unitOfWork;
            _shoppingListRepository = shoppingListRepository;
        }

        public async Task<Result<ShoppingList>> Handle(Command request, CancellationToken cancellationToken)
        {
            var (name, id) = request;
            var shoppingList = await _shoppingListRepository.GetByIdAsync(id);

            if (shoppingList is null)
            {
                return Result<ShoppingList>.Failure("Shopping List does not exist");
            }

            shoppingList.Name = name;

            await _unitOfWork.CompleteAsync(cancellationToken);
            return Result<ShoppingList>.Success(shoppingList);
        }
    }
}
