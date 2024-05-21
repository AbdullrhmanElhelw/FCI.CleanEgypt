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

        builder.Property(p => p.IsApproved)
            .HasDefaultValue(false)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(500)
            .IsRequired();

        builder.OwnsOne(p => p.Image, i =>
        {
            i.Property(im => im.FileName)
                .HasMaxLength(100)
                .IsRequired();

            i.Property(im => im.ContentType)
                .HasMaxLength(100)
                .IsRequired();

            i.Property(im => im.Data)
                .IsRequired();
        });
    }
}