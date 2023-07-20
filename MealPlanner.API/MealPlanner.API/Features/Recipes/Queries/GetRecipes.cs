using MediatR;

namespace MealPlanner.API.Features.Recipes.Queries;

public class GetRecipes
{
    public record Query() : IRequest<ICollection<RecipeResponse>>;

    public class Handler : IRequestHandler<Query, ICollection<RecipeResponse>>
    {
        public async Task<ICollection<RecipeResponse>> Handle(Query request, CancellationToken cancellationToken)
        {
            return (ICollection<RecipeResponse>)Enumerable.Empty<RecipeResponse>();
        }
    }

}
