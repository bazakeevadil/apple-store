using Application.Shared;
using Domain.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Categories.Commands;

public record UpdateCategoryCommand : IRequest
{
    public required string Name { get; init; }
    public required UpdateCategoryProps Props { get; init; }
}

public record UpdateCategoryProps
{
    public required string Name { get; init; }
}

internal class UpdateCategoryCommandHandler
    : IRequestHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _uow;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork uow)
    {
        _categoryRepository = categoryRepository;
        _uow = uow;
    }

    public async Task Handle(
        UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByName(request.Name)
            ?? throw new CategoryNotFoundException(request.Name);

        if (!string.IsNullOrWhiteSpace(request.Props.Name))
            category.Name = request.Props.Name;

        _categoryRepository.Update(category);
        await _uow.CommitAsync();
    }
}
