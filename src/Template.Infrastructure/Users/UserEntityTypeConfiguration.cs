using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Domain.Users;

namespace Template.Infrastructure.Users;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id);

        builder
            .Property(e => e.Id)
            .HasConversion(id => id.Value, value => new UserId(value));

        builder
            .Property(e => e.UserName)
            .HasConversion(u => u.Value, value => UserName.Create(value).Value);

        builder
            .Property(e => e.LastModified);
    }
}
