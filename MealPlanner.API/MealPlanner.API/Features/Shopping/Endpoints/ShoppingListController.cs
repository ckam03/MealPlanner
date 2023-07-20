using MealPlanner.API.Entities;
using MealPlanner.API.Features.Shopping.Commands;
using MealPlanner.API.Features.Shopping.Queries;
using MealPlanner.API.Features.Shopping.Requests;
using MealPlanner.API.Features.Shopping.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.API.Features.Shopping.Endpoints;

[Route("api/[controller]")]
[ApiController]
public class ShoppingListController : ControllerBase
{
    private readonly IMediator _mediator;

    public ShoppingListController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<ICollection<ShoppingListResponse>>> GetAsync(CancellationToken cancellationToken = default)
    {
        var shoppingLists = await _mediator.Send(new GetShoppingLists.Query(), cancellationToken);
        return Ok(shoppingLists);
    }

    [HttpGet("{id:guid}", Name = "GetByIdAsync")]
    public async Task<ActionResult<ShoppingListResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var shoppingList = await _mediator.Send(new GetShoppingList.Query(id), cancellationToken);
        return Ok(shoppingList.Value);
    }

    [HttpPost]
    public async Task<ActionResult<ShoppingList>> PostAsync([FromBody] string shoppingListName,
                                                            CancellationToken cancellationToken = default)
    {
        var shoppingList = await _mediator.Send(new CreateShoppingListCommand(shoppingListName), cancellationToken);
        return Ok(shoppingList);
    }

    [HttpPost("/api/ShoppingList/AddIngredient")]
    public async Task<ActionResult> AddToShoppingList([FromBody] AddToShoppingListRequest request,
                                                      CancellationToken cancellationToken = default)
    {
        //create validator for this endpoint
        await _mediator.Send(new AddItemToShoppingList.Command(request), cancellationToken);
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> UpdateShoppingList([FromBody] ShoppingListRequest request,
                                                       CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new UpdateShoppingList.Command(request.Name, request.ShoppingListId), cancellationToken);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new DeleteShoppingList.Command(id), cancellationToken);
        return Ok();
    }
}