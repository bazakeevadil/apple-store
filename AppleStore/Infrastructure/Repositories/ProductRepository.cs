using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task CreateAsync(Product entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(params string[] name)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(params Guid[] Id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Product>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetProductByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetProductByName(string name)
    {
        throw new NotImplementedException();
    }

    public void Update(Product entity)
    {
        throw new NotImplementedException();
    }
}
