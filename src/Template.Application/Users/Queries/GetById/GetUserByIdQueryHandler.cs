using FluentResults;
using Template.Application.Common.Queries;
using Template.Domain.Users;

namespace Template.Application.Users.Queries.GetById;

public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, Result<UserDto>>
{
    IUserRepository m_userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        m_userRepository = userRepository;
    }

    public async Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        User? user = await m_userRepository.GetByIdAsync(request.Id);

        if(user == null){
            return UserErrors.UserNotFound;
        }

        UserDto userDto = new UserDto(user.Id.Value, user.UserName.Value, user.LastModified);

        return Result.Ok(userDto);
    }
}
