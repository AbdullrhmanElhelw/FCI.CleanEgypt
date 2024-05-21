using FCI.CleanEgypt.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCI.CleanEgypt.Persistence.Configurations;

internal sealed class BaseIdentityEntityConfiguration : IEntityTypeConfiguration<BaseIdentityEntity>
{
    public void Configure(EntityTypeBuilder<BaseIdentityEntity> builder)
    {
        builder.HasKey(b => b.Id);
        builder.ToTable("BaseUsers");

        builder.UseTptMappingStrategy();

        builder.HasQueryFilter(e => !e.IsDeleted);

        builder.Property(e => e.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Email)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(e => e.City)
            .IsRequired();

        builder.Property(e => e.Street)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.DateOfBirth)
            .HasColumnType("date")
            .IsRequired();
    }
}