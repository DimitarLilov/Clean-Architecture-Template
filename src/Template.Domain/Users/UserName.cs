using FluentResults;

namespace Template.Domain.Users;

public sealed record UserName
{
    public string Value {get; }

    private UserName(string value) => Value = value;

    public static Result<UserName> Create(string value)
    {
        if(string.IsNullOrEmpty(value))
        {
            return UserErrors.UserNameIsEmpty;
        }

        return Result.Ok(new UserName(value));
    }
}
