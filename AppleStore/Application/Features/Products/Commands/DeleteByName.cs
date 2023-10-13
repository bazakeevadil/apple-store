using Application.Shared;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Products.Commands;

public record DeleteProductByNameCommand : IRequest
{
    public required string Name { get; init; }
}

internal class DeleteProductByNameCommandHandler
    : IRequestHandler<DeleteProductByNameCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _uow;

    public DeleteProductByNameCommandHandler(IProductRepository productRepository, IUnitOfWork uow)
    {
        _productRepository = productRepository;
        _uow = uow;
    }

    public async Task Handle(
        DeleteProductByNameCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByName(request.Name);

        if (product == null) return;

        _productRepository.DeleteByNameAsync(product);
        await _uow.CommitAsync();
    }
}