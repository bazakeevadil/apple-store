using Application.Features.Products.Commands;
using Application.Features.Products.Requests;
using Domain.Exceptions;
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

    [HttpGet("all-products")]
    public async Task<IActionResult> GetAll()
    {
        var request = new GetAllProductsQuery();

        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Add(
        CreateProductCommand request)
    {
        var response = await _mediator.Send(request);

        return Created("api/products/" + Uri.EscapeDataString(response.Name), response ?? new object());
    }

    [HttpGet("byname")]
    public async Task<IActionResult> GetByName(
        string name)
    {
        var request = new GetProductByNameQuery
        {
            Name = name,
        };

        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpGet("byid")]
    public async Task<IActionResult> GetById(
        Guid id)
    {
        var request = new GetProductByIdQuery
        {
            Id = id,
        };

        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpPatch("name")]
    public async Task<IActionResult> Update(
        UpdateProductProps props, string name)
    {
        try
        {
            var request = new UpdateProductProps
            {
                Name = name,
            };

            await _mediator.Send(request);

            return Ok();
        }
        catch (ProductNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("byname")]
    public async Task<IActionResult> Delete(
        string name)
    {
        var request = new DeleteProductByNameCommand
        {
            Name = name,
        };

        await _mediator.Send(request);

        return Ok();
    }

    [HttpDelete("byid")]
    public async Task<IActionResult> Delete(
        Guid id)
    {
        var request = new DeleteProductByIdCommand
        {
            Id = id,
        };

        await _mediator.Send(request);

        return Ok();
    }
}
