using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Create(Category entity)
    {
        _context.Categories.Add(entity);
    }

    public Task<List<Category>> GetAllAsync()
    {
        return _context.Categories.AsNoTracking().ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(Guid id)
    {
        var entity = await _context.Categories.FindAsync(id);

        if (entity != null)
            _context.Entry(entity).State = EntityState.Detached;

        return entity;
    }

    public Task<Category?> GetByName(string name)
    {
        return _context.Categories.AsNoTracking()
           .FirstOrDefaultAsync(c => c.Name == name);
    }

    public void Update(Category entity)
    {
        _context.Categories.Update(entity);
    }

    public async Task DeleteByIdAsync(params Guid[] id)
    {
        var entity = await _context.Categories.FindAsync(id);

        if (entity != null)
            _context.Categories.Remove(entity);
    }

    public void DeleteByNameAsync(Category entity)
    {
        _context.Categories.Remove(entity);
    }
}
