using FCI.CleanEgypt.Domain.Entities.Admins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCI.CleanEgypt.Persistence.Configurations;

internal sealed class AdminConfiguration : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.ToTable("Admins");

        builder.OwnsOne(a => a.ProfilePicture);

        builder.HasMany(a => a.Pins)
            .WithOne(p => p.Admin)
            .HasForeignKey(a => a.AdminId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}