namespace Template.Domain.Users;

public record struct UserId(Guid Value)
{
    public static UserId New() => new UserId(Guid.NewGuid());
}
