using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Template.Domain.Common.Storage;
using Template.Domain.Users;
using Template.Infrastructure.Database;
using Template.Infrastructure.Users;


namespace Template.Infrastructure;

public static class InfrastructureModule
{
    const string InMemoryDbName = "ApplicationInMemoryDatabase";
    public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, string? connectionString = null)
    {
        if(connectionString != null)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));
        }
        else
        {
            services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase(InMemoryDbName));
        }

        services.AddScoped<IStorage, Storage>();
        services.AddScoped<IUsersRepository, UsersRepository>();

        return services;
    }
}