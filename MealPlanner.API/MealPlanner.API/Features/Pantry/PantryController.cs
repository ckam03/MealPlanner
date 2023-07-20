using MealPlanner.API.Entities;
using MealPlanner.API.Features.Pantry.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.API.Features.Pantry;

[Route("api/[controller]")]
[ApiController]
public class PantryController : ControllerBase
{
    private readonly IMediator _mediator;

    public PantryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var ingredients = await _mediator.Send(new GetIngredients.Query());
        return Ok(ingredients);
    }

    //[HttpGet("id")]
    //public async Task <ActionResult<Ingredient>> GetByIdAsync([FromQuery] int id)
    //{
    //    var ingredient = await _pantryService.GetIngredientAsync(id);
    //    if (ingredient is null) { return NotFound(); }
    //    return Ok(ingredient);
    //}

    //[HttpPost]
    //public async Task<IActionResult> PostAsync([FromBody] string ingredientName)
    //{
    //    var ingredient = new Ingredient() { Name = ingredientName };
    //    await _pantryService.CreateIngredientAsync(ingredient);
    //    return Created("NewIngredient", ingredient);
    //}

    [HttpPut]
    public async Task<IActionResult> PutAsync([FromBody] int id)
    {
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromBody] int id)
    {
        return NoContent();
    }
}
