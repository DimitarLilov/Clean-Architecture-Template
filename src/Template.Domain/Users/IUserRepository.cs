using Template.Domain.Common.Storage;

namespace Template.Domain.Users;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByIdAsync(UserId userId);
}
