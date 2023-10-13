﻿using Application.Features.Categories.Commands;
using Application.Features.Categories.Requests;
using Application.Features.Products.Commands;
using Application.Features.Products.Requests;
using Domain.Entities;
using Domain.Exceptions;
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

    [HttpGet("all-categories")]
    public async Task<IActionResult> GetAll()
    {
        var request = new GetAllCategoryQuery();

        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpGet("byname")]
    public async Task<IActionResult> GetByName(
        string name)
    {
        var request = new GetCategoryByNameQuery
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
        var request = new GetCategoryByIdQuery
        {
            Id = id,
        };

        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpPatch("name")]
    public async Task<IActionResult> Update(
        UpdateCategoryProps props, string name)
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
        catch (CategoryNotFoundException ex)
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
        var request = new DeleteCategoryByNameCommand
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
        var request = new DeleteCategoryByIdCommand
        {
            Id = id,
        };

        await _mediator.Send(request);

        return Ok();
    }
}
