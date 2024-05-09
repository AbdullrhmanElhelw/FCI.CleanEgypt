using Microsoft.AspNetCore.Identity;

namespace FCI.CleanEgypt.Domain.Common;

public abstract class BaseIdentityEntity : IdentityUser<Guid>, ISoftDeleteEntity, IAuditableEntity
{
    protected BaseIdentityEntity()
    {
        Id = Guid.NewGuid();
        CreatedOnUtc = DateTime.UtcNow;
    }

    public string FirstName { get; protected set; }
    public string LastName { get; protected set; }
    public string City { get; protected set; }
    public string Street { get; protected set; }
    public DateTime DateOfBirth { get; protected set; }

    public DateTime CreatedOnUtc { get; protected set; }

    public DateTime? ModifiedOnUtc { get; protected set; }

    public bool IsDeleted { get; protected set; }

    public DateTime? DeletedOnUtc { get; protected set; }
}