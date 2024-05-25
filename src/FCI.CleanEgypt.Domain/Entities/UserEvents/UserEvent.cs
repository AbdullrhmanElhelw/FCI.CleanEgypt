using FCI.CleanEgypt.Domain.Common;
using FCI.CleanEgypt.Domain.Entities.Events;
using FCI.CleanEgypt.Domain.Entities.Users;

namespace FCI.CleanEgypt.Domain.Entities.UserEvents;

public sealed class UserEvent(Guid userId, Guid eventId) : IAuditableEntity, ISoftDeleteEntity
{
    public Guid UserId { get; private set; } = userId;

    public User User { get; }
    public Event Event { get; }
    public Guid EventId { get; private set; } = eventId;

    public DateTime CreatedOnUtc { get; } = DateTime.UtcNow;
    public DateTime? ModifiedOnUtc { get; }
    public bool IsDeleted { get; }
    public DateTime? DeletedOnUtc { get; }

    /*public void MarkAsDeleted(DateTime deletedOnUtc)
    {
        _isDeleted = true;
        _deletedOnUtc = deletedOnUtc;
    }

    public void UpdateModificationDate(DateTime modifiedOnUtc)
    {
        _modifiedOnUtc = modifiedOnUtc;
    }*/
}