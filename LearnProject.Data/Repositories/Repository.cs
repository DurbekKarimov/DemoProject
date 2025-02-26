using LearnProject.Data.DbContexts;
using LearnProject.Data.IRepositories;
using LearnProject.Domain.Commons;
using Microsoft.EntityFrameworkCore;

namespace LearnProject.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly AppDbContext dbContext;
    private readonly DbSet<TEntity> dbSet;

    public Repository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.dbSet = dbContext.Set<TEntity>();
    }

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        var result = await dbSet.AddAsync(entity);

        await dbContext.SaveChangesAsync();

        return result.Entity;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entity = await dbSet.FirstOrDefaultAsync(e => e.Id == id);
        dbSet.Remove(entity);

        return await dbContext.SaveChangesAsync() > 0;
    }
   
    public IQueryable<TEntity> SelectAll()
        => dbSet;

    public async Task<TEntity> SelectByIdAsync(long id)
        => await dbSet.FirstOrDefaultAsync(e => e.Id == id);

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var result = dbContext.Update(entity);
        await dbContext.SaveChangesAsync();

        return result.Entity;
    }
}
