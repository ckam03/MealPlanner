using MealPlanner.API.Entities;
using MealPlanner.API.Interfaces;
using MediatR;

namespace MealPlanner.API.Features.Shopping.Commands;

public record CreateShoppingListCommand(string ShoppingListName) : IRequest<ShoppingList>;

public class Handler : IRequestHandler<CreateShoppingListCommand, ShoppingList>
{
    private readonly IShoppingListRepository _shoppingListRepository;
    private readonly IUnitOfWork _unitOfWork;

    public Handler(IShoppingListRepository shoppingListRepository, IUnitOfWork unitOfWork)
    {
        _shoppingListRepository = shoppingListRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ShoppingList> Handle(CreateShoppingListCommand request, CancellationToken cancellationToken)
    {
        var shoppingList = new ShoppingList()
        {
            Id = Guid.NewGuid(),
            Name = request.ShoppingListName
        };

        _shoppingListRepository.Add(shoppingList);
        await _unitOfWork.CompleteAsync(cancellationToken);

        return shoppingList;
    }
}
