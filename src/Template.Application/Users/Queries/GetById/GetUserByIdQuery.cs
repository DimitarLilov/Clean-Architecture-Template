using FluentResults;
using Template.Application.Common.Queries;
using Template.Domain.Users;

namespace Template.Application.Users.Queries.GetById;

public record GetUserByIdQuery(UserId Id) : IQuery<Result<UserDto>>;