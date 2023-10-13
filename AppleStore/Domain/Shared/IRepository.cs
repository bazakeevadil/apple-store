namespace Domain.Shared;

public interface IRepository<TEntity>
{
    Task<List<TEntity>> GetAllAsync();
    Task CreateAsync(TEntity entity);
    void Update(TEntity entity);
    Task<bool> DeleteAsync(params string[] name);
    Task<bool> DeleteAsync(params Guid[] Id);
}
