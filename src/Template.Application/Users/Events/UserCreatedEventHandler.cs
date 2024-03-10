using MediatR;
using Microsoft.Extensions.Logging;
using Template.Domain.Users;

namespace Template.Application.Users.Events;

public class UserCreatedEventHandler : INotificationHandler<UserCreatedEvent>
{
    ILogger<UserCreatedEventHandler> m_logger;

    public UserCreatedEventHandler(ILogger<UserCreatedEventHandler> logger)
    {
        m_logger = logger;
    }

    public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
    {
        m_logger.LogWarning("");

        await Task.CompletedTask;
    }
}
