using Application.Contract;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Features.Categories.Requests;

public record GetAllCategoryQuery : IRequest<List<CategoryDto>> { }

public class GetAllCategoryQueryHandler
: IRequestHandler<GetAllCategoryQuery, List<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryDto>> Handle(
        GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync();

        var response = categories.Adapt<List<CategoryDto>>();

        return response;
    }
}
