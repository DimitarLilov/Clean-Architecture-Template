using Microsoft.EntityFrameworkCore;
using Template.Domain.Common.Aggregates;
using Template.Domain.Common.Storage;

namespace Template.Infrastructure.Database;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : AggregateRoot
{
    protected ApplicationContext DbContext;

    protected Repository(ApplicationContext dbContext) => DbContext = dbContext;

    public async Task Create(TEntity entity) =>  await DbContext.Set<TEntity>().AddAsync(entity);

    public void Delete(TEntity entity) => DbContext.Set<TEntity>().Remove(entity);

    public async Task<IReadOnlyList<TEntity>> GetAll() => await DbContext.Set<TEntity>().ToListAsync();

    public void Update(TEntity entity) => DbContext.Set<TEntity>().Update(entity);
}
