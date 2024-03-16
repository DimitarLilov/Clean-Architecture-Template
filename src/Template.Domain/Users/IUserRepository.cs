using Template.Domain.Common.Storage;

namespace Template.Domain.Users;

public interface IUsersRepository : IRepository<User>
{
    Task<User?> GetByIdAsync(UserId userId);
}
