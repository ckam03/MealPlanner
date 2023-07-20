using FluentAssertions;
using MealPlanner.API.Features.Recipes;
using MealPlanner.API.Features.Recipes.Endpoints;
using MealPlanner.API.Features.Recipes.Services;
using Moq;

namespace MealPlanner.API.Tests.Recipes;

public class RecipeControllerTests
{
    private readonly Mock<IRecipeService> _recipeService = new();

    // [Fact]
    // public async Task Search_For_Recipes_ReturnsRecipes()
    // {
    //     //Arrange
    //     const string ingredient = "chicken";
    //     _recipeService.Setup(service => service.GetRecipesAsync(ingredient));
    //     var controller = new RecipeController(_recipeService.Object);
    //     //Act
    //     var result = await controller.GetAsync(ingredient);

    //     //Assert
    //     result.Should().BeOfType<RecipeResponse>();
    // }
}