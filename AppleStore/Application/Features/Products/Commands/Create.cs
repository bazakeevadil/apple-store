using Application.Contract;
using Application.Shared;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Features.Products.Commands;

public record CreateProductCommand : IRequest<ProductDto>
{
    public required string Name { get; init; }
    public required Guid CategoryId { get; init; }
}

internal class CreateProductCommandHandler
    : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _uow;

    public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork uow)
    {
        _productRepository = productRepository;
        _uow = uow;
    }

    public async Task<ProductDto> Handle(
        CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = request.Adapt<Product>();

        _productRepository.Create(product);
        await _uow.CommitAsync();

        var response = product.Adapt<ProductDto>();

        return response;
    }
}
