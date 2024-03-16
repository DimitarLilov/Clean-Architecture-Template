using Microsoft.EntityFrameworkCore;
using Template.Domain.Users;
using Template.Infrastructure.Database;

namespace Template.Infrastructure.Users;

public class UsersRepository : Repository<User>, IUsersRepository
{
    protected UsersRepository(ApplicationContext dbContext) : base(dbContext)
    {
    }

    public async Task<User?> GetByIdAsync(UserId userId)
    {
        return await DbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id == userId);
    }
}
