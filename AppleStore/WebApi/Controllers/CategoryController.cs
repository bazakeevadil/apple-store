using Application.Features.Categories.Commands;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController,Route("api/сategories")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Add(
        CreateCategoryCommand request)
    {
        var response = await _mediator.Send(request);

        return Created($"api/сategories/ + {response.Id}", response);
    }
}
