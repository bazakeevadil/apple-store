using Application.Shared;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Categories.Commands;

public record DeleteCategoryByIdCommand : IRequest
{
    public required Guid Id { get; init; }
}

internal class DeleteCategoryByIdCommandHandler
    : IRequestHandler<DeleteCategoryByIdCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _uow;

    public DeleteCategoryByIdCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork uow)
    {
        _categoryRepository = categoryRepository;
        _uow = uow;
    }

    public async Task Handle(
        DeleteCategoryByIdCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);

        if (category == null) return;

        await _categoryRepository.DeleteByIdAsync(category.Id);
        await _uow.CommitAsync();
    }
}
