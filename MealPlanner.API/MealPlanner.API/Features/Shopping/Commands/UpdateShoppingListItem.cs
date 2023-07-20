using MealPlanner.API.Entities;
using MealPlanner.API.Interfaces;
using MealPlanner.API.Shared;
using MediatR;

namespace MealPlanner.API.Features.Shopping.Commands;

public static class UpdateShoppingListItem
{
    public record Command(ShoppingListItem Item) : IRequest<Result<ShoppingListItem>>;

    public class Handler : IRequestHandler<Command, Result<ShoppingListItem>>
    {
        private readonly IShoppingListItemRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IShoppingListItemRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<ShoppingListItem>> Handle(Command request, CancellationToken cancellationToken)
        {
            _repository.Update(request.Item);
            await _unitOfWork.CompleteAsync(cancellationToken);

            return Result<ShoppingListItem>.Success(request.Item);
        }
    }

}