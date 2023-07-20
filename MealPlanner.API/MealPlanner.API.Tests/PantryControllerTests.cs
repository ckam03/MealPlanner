using FluentAssertions;
using MealPlanner.API.Entities;
using MealPlanner.API.Features.Pantry;
using MealPlanner.API.Features.Pantry.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace MealPlanner.API.Tests;

public class PantryControllerTests
{
    private readonly Mock<IMediator> _mediator = new();

    [Fact]
    public async Task GetPantryItems_ReturnsOk()
    {
        //Arrange
        var ingredients = new List<Ingredient>
        {
            new() { Id = Guid.NewGuid(), Name = "Carrot" },
            new() { Id = Guid.NewGuid(), Name = "Pear" }
        };

        var query = new GetIngredients.Query();
        //_mediator.Setup(repo => await repo.Send(query)).ReturnsAsync(ingredients);
        ////var pantryController = new PantryController(_pantryService.Object);

        ////Act
        //var result = await pantryController.GetAsync();

        ////Assert
        //result.Should().BeOfType<OkObjectResult>();
    }

    //[Fact]
    //public async Task CreateIngredient_IsSuccessful()
    //{
    //    //Arrange
    //    const string ingredient = "kimchi";
    //    var pantryController = new PantryController(_pantryService.Object);

    //    //Act
    //    var result = await pantryController.PostAsync(ingredient);

    //    //Assert
    //    var created = result as CreatedResult;
    //    Assert.NotNull(created);
    //}
}