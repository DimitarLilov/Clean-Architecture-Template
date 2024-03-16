using MediatR;
using Template.Domain.Common.Aggregates;
using Template.Domain.Common.DomainEvents;
using Template.Domain.Common.Storage;

namespace Template.Infrastructure.Database;

public class Storage : IStorage
{
    IPublisher m_publisher;

    ApplicationContext m_context;

    public Storage(IPublisher publisher, ApplicationContext context)
    {
        m_publisher = publisher;
        m_context = context;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        List<AggregateRoot> entities = GetEntities(m_context);
        List<IDomainEvent> events = GetEvents(entities);

        await m_context.SaveChangesAsync(cancellationToken);

        foreach(var domainEvent in events)
        {
            await m_publisher.Publish(domainEvent, cancellationToken);
        }

        entities.ForEach(e => e.ClearDomainEvents());
    }

    List<AggregateRoot> GetEntities(ApplicationContext context) => context.ChangeTracker.Entries<AggregateRoot>().Select(e => e.Entity).ToList();

    List<IDomainEvent> GetEvents(List<AggregateRoot> entities) => entities.Where(e => e.DomainEvents.Any()).SelectMany(e => e.DomainEvents).ToList();
}
