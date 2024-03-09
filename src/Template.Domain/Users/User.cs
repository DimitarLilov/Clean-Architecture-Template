using Template.Domain.Common.Aggregates;

namespace Template.Domain.Users;

public class User : AggregateRoot
{
    public User(UserName userName, DateTime lastModified)
    {
        Id = UserId.New();
        UserName = userName;
        LastModified = lastModified;

        RaiseDomainEvent(new UserCreatedEvent(Id));
    }

    public UserId Id { get; }

    public UserName UserName { get; }

    public DateTime LastModified { get; }
}
