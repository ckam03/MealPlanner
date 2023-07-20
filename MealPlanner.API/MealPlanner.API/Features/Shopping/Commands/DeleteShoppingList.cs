using MealPlanner.API.Interfaces;
using MediatR;

namespace MealPlanner.API.Features.Shopping.Commands;

public class DeleteShoppingList
{
    public record Command(Guid Id) : IRequest;

    public class Handler : IRequestHandler<Command>
    {
        private readonly IShoppingListRepository _shoppingListRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IUnitOfWork unitOfWork, IShoppingListRepository shoppingListRepository)
        {
            _unitOfWork = unitOfWork;
            _shoppingListRepository = shoppingListRepository;
        }

        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var shoppingList = await _shoppingListRepository.GetByIdAsync(request.Id);

            _shoppingListRepository.Delete(shoppingList);
            await _unitOfWork.CompleteAsync(cancellationToken);
        }
    }
}
