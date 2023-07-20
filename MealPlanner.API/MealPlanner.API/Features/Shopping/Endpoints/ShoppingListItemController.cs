using MealPlanner.API.Entities;
using MealPlanner.API.Features.Shopping.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.API.Features.Shopping.Endpoints;

[ApiController]
[Route("api/[controller]")]
public class ShoppingListItemController : ControllerBase
{
    private readonly IMediator _mediator;

    public ShoppingListItemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPut]
    public async Task<IActionResult> UpdateItem([FromBody] ShoppingListItem request,
                                                CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new UpdateShoppingListItem.Command(request), cancellationToken);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteItem([FromQuery] Guid id)
    {
        return Ok();
    }
}