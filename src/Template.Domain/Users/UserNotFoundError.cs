using Template.Domain.Common.Errors;

namespace Template.Domain.Users;

public class UserNotFoundError : DomainError
{
    public UserNotFoundError(string message, string code) : base(message, code)
    {
        WithMetadata(nameof(ErrorCode), ErrorCode.NotFound);
    }
}
