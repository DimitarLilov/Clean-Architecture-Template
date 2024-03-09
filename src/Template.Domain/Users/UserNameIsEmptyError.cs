using Template.Domain.Common.Errors;

namespace Template.Domain.Users;

public class UserNameIsEmptyError : DomainError
{
    public UserNameIsEmptyError(string message, string code) : base(message, code)
    {
        WithMetadata(nameof(ErrorCode), ErrorCode.Invalid);
    }
}
