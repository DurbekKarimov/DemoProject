using LearnProject.Data.IRepositories;
using LearnProject.Domain.Commons;

namespace LearnProject.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    public Task<TEntity> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<TEntity>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> InsertAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
}
