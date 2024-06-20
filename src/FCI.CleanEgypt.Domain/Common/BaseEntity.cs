namespace FCI.CleanEgypt.Domain.Common;

public abstract class BaseEntity : IEquatable<BaseEntity>
{
    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedOnUtc = DateTime.UtcNow;
    }

    public Guid Id { get; protected set; }
    public bool IsDeleted { get; protected set; }

    public DateTime? DeletedOnUtc { get; protected set; }

    public DateTime CreatedOnUtc { get; protected set; }

    public DateTime? ModifiedOnUtc { get; protected set; }

    public bool Equals(BaseEntity? other)
    {
        if (ReferenceEquals(null, other)) return false;
        return ReferenceEquals(this, other) || Id.Equals(other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((BaseEntity)obj);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode() ^ 31;
    }

    public static bool operator ==(BaseEntity? left, BaseEntity? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(BaseEntity? left, BaseEntity? right)
    {
        return !Equals(left, right);
    }
}