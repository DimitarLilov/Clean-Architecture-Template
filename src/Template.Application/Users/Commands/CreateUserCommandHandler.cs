using FluentResults;
using Template.Application.Common.Commands;
using Template.Domain.Common.Storage;
using Template.Domain.Users;

namespace Template.Application.Users.Commands;

public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Result<Guid>>
{
    IStorage m_storage;

    IUsersRepository m_userRepository;

    TimeProvider m_timeProvider;

    public CreateUserCommandHandler(IStorage storage, IUsersRepository userRepository, TimeProvider timeProvider)
    {
        m_storage = storage;
        m_userRepository = userRepository;
        m_timeProvider = timeProvider;
    }

    public async Task<Result<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        Result<UserName> userName = UserName.Create(request.Name);

        if(userName.IsFailed)
        {
            return Result.Fail(userName.Errors);
        }

        User user = new (userName.Value, m_timeProvider.GetUtcNow().UtcDateTime);

        await m_userRepository.Create(user);

        await m_storage.SaveChangesAsync(cancellationToken);

        return Result.Ok<Guid>(user.Id.Value); 
    }
}
