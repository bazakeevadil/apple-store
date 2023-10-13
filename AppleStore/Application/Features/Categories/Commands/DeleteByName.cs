using Application.Shared;
using Domain.Repositories;
using MediatR;


namespace Application.Features.Categories.Commands;

public record DeleteCategoryByNameCommand : IRequest
{
    public required string Name { get; init; }
}

internal class DeleteCategoryByNameCommandHandler
    : IRequestHandler<DeleteCategoryByNameCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _uow;

    public DeleteCategoryByNameCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork uow)
    {
        _categoryRepository = categoryRepository;
        _uow = uow;
    }

    public async Task Handle(
        DeleteCategoryByNameCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByName(request.Name);

        if (category == null) return;

        _categoryRepository.DeleteByNameAsync(category);
        await _uow.CommitAsync();
    }
}
