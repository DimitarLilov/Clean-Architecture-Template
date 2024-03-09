using Template.Domain.Common.DomainEvents;

namespace Template.Domain.Users;

public record UserCreatedEvent(UserId UserId) : IDomainEvent;
