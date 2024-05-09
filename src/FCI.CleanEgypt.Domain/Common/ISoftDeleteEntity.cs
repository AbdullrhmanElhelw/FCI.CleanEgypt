namespace FCI.CleanEgypt.Domain.Common;

public interface ISoftDeleteEntity
{
    bool IsDeleted { get; }
    DateTime? DeletedOnUtc { get; }
}