using Application.Shared;
using Domain.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Products.Commands;

public record UpdateProductCommand : IRequest
{
    public required string Name { get; init; }
    public required UpdateProductProps Props { get; init; }
}

public record UpdateProductProps
{
    public required string Name { get; init; }
}

internal class UpdateProductCommandHandler
    : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _uow;

    public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork uow)
    {
        _productRepository = productRepository;
        _uow = uow;
    }

    public async Task Handle(
        UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByName(request.Name)
            ?? throw new ProductNotFoundException(request.Name);

        if (!string.IsNullOrWhiteSpace(request.Props.Name))
            product.Name = request.Props.Name;

        _productRepository.Update(product);
        await _uow.CommitAsync();
    }
}
