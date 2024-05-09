using FCI.CleanEgypt.Domain.Entities.UserEvents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FCI.CleanEgypt.Persistence.Configurations;

internal sealed class UserEventConfiguration : IEntityTypeConfiguration<UserEvent>
{
    public void Configure(EntityTypeBuilder<UserEvent> builder)
    {
        builder.ToTable("UserEvents");
        builder.HasKey(e => new { e.EventId, e.UserId });

        builder.HasQueryFilter(e => !e.User.IsDeleted);
        builder.HasQueryFilter(e => !e.Event.IsDeleted);
    }
}