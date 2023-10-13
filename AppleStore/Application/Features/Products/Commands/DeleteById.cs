using Application.Shared;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Products.Commands;

public record DeleteProductByIdCommand : IRequest
{
    public required Guid Id { get; init; }
}

internal class DeleteProductByIdCommandHandler
    : IRequestHandler<DeleteProductByIdCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _uow;

    public DeleteProductByIdCommandHandler(IProductRepository productRepository, IUnitOfWork uow)
    {
        _productRepository = productRepository;
        _uow = uow;
    }

    public async Task Handle(
        DeleteProductByIdCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product == null) return;

        await _productRepository.DeleteByIdAsync(product.Id);
        await _uow.CommitAsync();
    }
}
