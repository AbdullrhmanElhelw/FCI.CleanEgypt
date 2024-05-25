using FCI.CleanEgypt.Domain.Entities.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCI.CleanEgypt.Persistence.Configurations;

internal sealed class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events");

        builder.HasKey(e => e.Id);

        builder.HasQueryFilter(e => !e.IsDeleted);

        builder.Property(e => e.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(e => e.Date)
            .IsRequired();

        builder.Property(e => e.Detalis)
            .IsRequired();

        builder.HasMany(e => e.UserEvents)
            .WithOne(e => e.Event)
            .HasForeignKey(e => e.EventId);
    }
}