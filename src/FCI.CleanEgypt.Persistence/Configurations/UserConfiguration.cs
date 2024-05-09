using FCI.CleanEgypt.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCI.CleanEgypt.Persistence.Configurations;

internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("NormalUsers");

        builder.OwnsOne(u => u.ProfilePicture);

        builder.OwnsOne(u => u.Points);

        builder.HasMany(u => u.UserEvents)
            .WithOne(us => us.User)
            .HasForeignKey(u => u.UserId);

        builder.HasMany(u => u.Pins)
            .WithOne(p => p.User)
            .HasForeignKey(u => u.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}