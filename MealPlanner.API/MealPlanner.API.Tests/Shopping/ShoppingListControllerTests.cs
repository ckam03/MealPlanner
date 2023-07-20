using FakeItEasy;
using FluentAssertions;
using MealPlanner.API.Entities;
using MealPlanner.API.Features.Shopping.Endpoints;
using MealPlanner.API.Features.Shopping.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace MealPlanner.API.Tests.Shopping;

public class ShoppingListControllerTests
{
    private readonly Mock<IMediator> _mediator = new();

    [Fact]
    public async Task GetAll_ShoppingLists_Should_ReturnOk()
    {
        //Arrange
        var shoppingLists = A.CollectionOfDummy<ShoppingList>(5).AsEnumerable();
        var shoppingListController = new ShoppingListController(_mediator.Object);

        //Act
        var response = await shoppingListController.GetAsync();

        //Assert
        response.Should().NotBeNull();
    }

    [Fact]
    public async Task Create_NewShoppingList_Should_ReturnCreatedAtRouteResult()
    {
        //Arrange
        var shoppingListController = new ShoppingListController(_mediator.Object);

        //Act
        var response = await shoppingListController.PostAsync("TestListName");

        //Assert
        var createdList = (response.Result as CreatedAtRouteResult)?.Value as ShoppingList;
        response.Should().BeOfType<ActionResult<ShoppingList>>();
    }

    [Fact]
    public async Task AddItem_ToShoppingList_ReturnsOk()
    {
        //Arrange
        var request = new AddToShoppingListRequest("Apple", 0, "g", Guid.NewGuid());
        var shoppingListController = new ShoppingListController(_mediator.Object);

        //Act
        var result = await shoppingListController.AddToShoppingList(request);

        //Assert
        result.Should().BeOfType<OkResult>();
    }
}
