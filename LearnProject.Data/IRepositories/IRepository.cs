using LearnProject.Domain.Commons;

namespace LearnProject.Data.IRepositories;

public interface IRepository<TEntity> where TEntity : Auditable
{
    Task<TEntity> DeleteAsync(long id);
    Task<TEntity> GetByIdAsync(long id);
    Task<IQueryable<TEntity>> GetAllAsync();
    Task<TEntity> InsertAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
}
