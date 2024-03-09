using FluentResults;

namespace Template.Domain.Common.Errors;

public class DomainError : Error
{
    protected DomainError(string message, string code): base(message){
        WithMetadata("ErrorCode", code);
    }
}
