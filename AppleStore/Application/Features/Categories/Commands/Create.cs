using Application.Contract;
using Application.Shared;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Features.Categories.Commands;

public record CreateCategoryCommand : IRequest<CategoryDto>
{
    public required string Name { get; init; }
}

internal class CreateCategoryCommandHandler
    : IRequestHandler<CreateCategoryCommand, CategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _uow;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork uow)
    {
        _categoryRepository = categoryRepository;
        _uow = uow;
    }

    public async Task<CategoryDto> Handle(
        CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = request.Adapt<Category>();

        _categoryRepository.Create(category);
        await _uow.CommitAsync();

        var response = category.Adapt<CategoryDto>();

        return response;
    }
}

