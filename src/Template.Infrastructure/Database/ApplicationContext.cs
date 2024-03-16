using Microsoft.EntityFrameworkCore;
using Template.Domain.Users;

namespace Template.Infrastructure.Database;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) :base(options)
    {
    }

    public DbSet<User> Users { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}
