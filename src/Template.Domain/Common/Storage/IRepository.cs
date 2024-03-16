using Template.Domain.Common.Aggregates;

namespace Template.Domain.Common.Storage;

public interface IRepository<TEntity> where TEntity : AggregateRoot
{
    Task<IReadOnlyList<TEntity>> GetAll();

    Task Create(TEntity entity);

    void Update(TEntity entity);

    void Delete(TEntity entity);
}
