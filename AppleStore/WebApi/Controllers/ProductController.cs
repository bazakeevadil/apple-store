using Application.Features.Products.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController,Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Add(
        CreateProductCommand request)
    {
        var response = await _mediator.Send(request);

        return Created("api/products/" + Uri.EscapeDataString(response.Name), response ?? new object());
    }
}
