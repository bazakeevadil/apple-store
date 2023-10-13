using Domain.Entities;
using Domain.Shared;

namespace Domain.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<Product?> GetProductByIdAsync(Guid id);
    Task<Product?> GetProductByName(string name);
}
