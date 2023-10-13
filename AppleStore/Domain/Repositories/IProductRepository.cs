using Domain.Entities;
using Domain.Shared;

namespace Domain.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<Product?> GetByIdAsync(Guid id);
    Task<Product?> GetByName(string name);
}
