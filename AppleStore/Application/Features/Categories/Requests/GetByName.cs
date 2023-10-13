using Application.Contract;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Features.Categories.Requests;

public record GetCategoryByNameQuery : IRequest<CategoryDto>
{
    public required string Name { get; init; }
}

internal class GetCategoryByNameQueryHandler
    : IRequestHandler<GetCategoryByNameQuery, CategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByNameQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<CategoryDto> Handle(
        GetCategoryByNameQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByName(request.Name);

        var response = category.Adapt<CategoryDto>();

        return response;
    }
}
