using FCI.CleanEgypt.Domain.Entities.Pins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCI.CleanEgypt.Persistence.Configurations;

internal sealed class PinConfiguration : IEntityTypeConfiguration<Pin>
{
    public void Configure(EntityTypeBuilder<Pin> builder)
    {
        builder.ToTable("Pins");

        builder.HasKey(p => p.Id);

        builder.HasQueryFilter(p => !p.IsDeleted);

        builder.Property(p => p.City)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.Street)
            .HasMaxLength(100)
            .IsRequired();
    }
}