using FluentResults;
using Template.Application.Common.Commands;

namespace Template.Application.Users.Commands;

public record CreateUserCommand(string Name) : ICommond<Result<Guid>>
{

}
