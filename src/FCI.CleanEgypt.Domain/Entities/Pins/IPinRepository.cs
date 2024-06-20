namespace FCI.CleanEgypt.Domain.Entities.Pins;

public interface IPinRepository
{
    Task<Pin?> GetPinAsync(Guid pinId, CancellationToken cancellationToken = default!);

    Task<int> GetPinCountAsync(CancellationToken cancellationToken = default!);

    Task<int> GetPinCountAsync(Guid userId, CancellationToken cancellationToken = default!);

    Task<IReadOnlyCollection<Pin>> GetAllPinsAsync(Guid userId, int pageNumber, int pageSize, CancellationToken cancellationToken = default!);

    Task DeletePin(Guid pinId, CancellationToken cancellationToken = default!);

    /*    Task<Pin?> FindPinAsync(string city, string street, CancellationToken cancellationToken = default!);
    */

    void Create(Pin pin);

    void Update(Pin pin);
}