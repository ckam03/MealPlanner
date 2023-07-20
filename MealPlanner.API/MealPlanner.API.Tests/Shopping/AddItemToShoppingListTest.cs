using FluentAssertions;
using MealPlanner.API.Entities;
using MealPlanner.API.Features.Shopping.Commands;
using MealPlanner.API.Features.Shopping.Requests;
using MealPlanner.API.Interfaces;
using MealPlanner.API.Shared;
using Moq;

namespace MealPlanner.API.Tests.Shopping;

public class AddItemToShoppingListTest
{
    private readonly Mock<IShoppingListRepository> _shoppingListRepoMock = new();
    private readonly Mock<IShoppingListItemRepository> _shoppingListItemRepoMock = new();
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();

    [Fact]
    public async Task AddIngredient_To_ShoppingList()
    {
        //Arrange
        var shoppingList = new ShoppingList
        {
            Id = Guid.NewGuid(),
            Name = "test"
        };

        _shoppingListRepoMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(shoppingList);

        var request = new AddToShoppingListRequest("Pizza", 10, "g", shoppingList.Id);
        var command = new AddItemToShoppingList.Command(request);
        var handlerStub = new AddItemToShoppingList.Handler(_shoppingListRepoMock.Object,
                                                            _shoppingListItemRepoMock.Object,
                                                            _unitOfWorkMock.Object);
        //Act
        Result<ShoppingListItem> result = await handlerStub.Handle(command, default);

        //Assert
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task AddIngredient_To_ShoppingList_ThatDoesntExistIsFailure()
    {
        var shoppingList = new ShoppingList
        {
            Id = Guid.NewGuid(),
            Name = "test"
        };

        var id = Guid.NewGuid();
        var request = new AddToShoppingListRequest("Pizza", 10, "g", id);

        var command = new AddItemToShoppingList.Command(request);
        var handlerStub = new AddItemToShoppingList.Handler(_shoppingListRepoMock.Object,
                                                            _shoppingListItemRepoMock.Object,
                                                            _unitOfWorkMock.Object);

        //Act
        Result<ShoppingListItem> result = await handlerStub.Handle(command, default);

        //Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be($"Id: {id} does not exist");
    }
}
