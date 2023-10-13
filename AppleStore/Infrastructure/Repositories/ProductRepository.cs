using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<List<Product>> GetAllAsync()
    {
        return _context.Products.AsNoTracking().ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        var entity = await _context.Products.FindAsync(id);

        if (entity != null)
            _context.Entry(entity).State = EntityState.Detached;

        return entity;
    }

    public Task<Product?> GetByName(string name)
    {
        return _context.Products.AsNoTracking()
            .FirstOrDefaultAsync(p => p.Name == name);
    }

    public void Update(Product entity)
    {
        _context.Products.Update(entity);
    }

    public void Create(Product entity)
    {
        _context.Products.Add(entity);
    }

    public void DeleteByNameAsync(Product entity)
    {
        _context.Products.Remove(entity);
    }

    public async Task DeleteByIdAsync(params Guid[] id)
    {
        var entity = await _context.Products.FindAsync(id);

        if (entity != null)
            _context.Products.Remove(entity);
    }
}
