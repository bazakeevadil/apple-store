using Application.Contract;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Features.Products.Requests;

public record GetProductByNameQuery : IRequest<ProductDto>
{
    public required string Name { get; init; }
}

internal class GetProductByNameQueryHandler
    : IRequestHandler<GetProductByNameQuery, ProductDto>
{
    private readonly IProductRepository _productRepository;

    public GetProductByNameQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDto> Handle(
        GetProductByNameQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByName(request.Name);

        var response = product.Adapt<ProductDto>();

        return response;
    }
}
