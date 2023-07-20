using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.API.Features.MealPlanner.Endpoints;

[Route("/MealPlanner")]
[ApiController]
public class MealPlanController : ControllerBase
{
    private readonly IMediator _mediator;

    public MealPlanController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult> GetMealPlan(DateOnly From, DateOnly To) 
    {
        return Ok();
    }

    [HttpGet("/MealPlanner/Date")]
    public async Task<ActionResult> GetMealByDate(DateOnly Date)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult> AddToMealPlan() 
    {
        return Ok();
    }
}
