namespace Template.Domain.Common.Storage;

public interface IStorage
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
