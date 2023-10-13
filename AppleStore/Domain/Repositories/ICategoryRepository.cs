using Domain.Entities;
using Domain.Shared;

namespace Domain.Repositories;

public interface ICategoryRepository : IRepository<Category>
{
    Task<Category?> GetByIdAsync(Guid id);
    Task<Category?> GetByName(string name);
}
