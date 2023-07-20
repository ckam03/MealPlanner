using MealPlanner.API.Entities;
using MealPlanner.API.Features.Shopping.Requests;
using MealPlanner.API.Interfaces;
using MealPlanner.API.Shared;
using MediatR;

namespace MealPlanner.API.Features.Shopping.Commands;

public static class AddItemToShoppingList
{
    public record Command(AddToShoppingListRequest Request): IRequest<Result<ShoppingListItem>>;

    public class Handler : IRequestHandler<Command, Result<ShoppingListItem>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IShoppingListRepository _shoppingListRepository;
        private readonly IShoppingListItemRepository _shoppingListItemRepository;

        public Handler(IShoppingListRepository shoppingListRepository,
                       IShoppingListItemRepository shoppingListItemRepository,
                       IUnitOfWork unitOfWork)
        {
            _shoppingListRepository = shoppingListRepository;
            _shoppingListItemRepository = shoppingListItemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<ShoppingListItem>> Handle(Command request, CancellationToken cancellationToken)
        {
            var (name, _, _, shoppingListId) = request.Request;
            var shoppingList = await _shoppingListRepository.GetByIdAsync(shoppingListId);

            if (shoppingList is null)
            {
                return Result<ShoppingListItem>.Failure($"Id: {shoppingListId} does not exist");
            }

            var shoppingListItem = new ShoppingListItem()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Amount = 0,
                Unit = string.Empty,
                ShoppingListId = shoppingListId
            };

            _shoppingListItemRepository.Add(shoppingListItem);
            await _unitOfWork.CompleteAsync(cancellationToken);

            return Result<ShoppingListItem>.Success(shoppingListItem);
        }
    }
}