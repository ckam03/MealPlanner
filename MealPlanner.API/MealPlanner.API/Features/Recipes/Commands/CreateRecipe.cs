using MealPlanner.API.Entities;
using MealPlanner.API.Interfaces;
using MediatR;

namespace MealPlanner.API.Features.Recipes.Commands;


public record CreateRecipeCommand(CreateRecipeRequest Request) : IRequest;

public class Handler : IRequestHandler<CreateRecipeCommand>
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public Handler(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork)
    {
        _recipeRepository = recipeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        var (Name, Ingredients, Instructions) = request.Request;
        var recipe = new Recipe
        {
            Id = Guid.NewGuid(),
            Name = Name,
            Ingredients = Ingredients,
            Instructions = Instructions
        };

        _recipeRepository.Add(recipe);
        await _unitOfWork.CompleteAsync(cancellationToken);
    }
}
