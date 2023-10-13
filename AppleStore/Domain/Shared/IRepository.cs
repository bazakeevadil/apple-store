using Domain.Entities;

namespace Domain.Shared;

public interface IRepository<TEntity>
{
    Task<List<TEntity>> GetAllAsync();
    void Create(TEntity entity);
    void Update(TEntity entity);
    void DeleteByNameAsync(TEntity entity);
    Task DeleteByIdAsync(params Guid[] id);
}
