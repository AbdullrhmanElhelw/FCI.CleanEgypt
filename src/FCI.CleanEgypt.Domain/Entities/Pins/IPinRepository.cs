namespace FCI.CleanEgypt.Domain.Entities.Pins;

public interface IPinRepository
{
    Task<Pin?> GetPin(Guid pinId, CancellationToken cancellationToken = default!);

    Task<int> GetPinCountAsync(CancellationToken cancellationToken = default!);

    Task<int> GetPinCountAsync(Guid userId, CancellationToken cancellationToken = default!);

    Task<IReadOnlyCollection<Pin>> GetAllPinsAsync(Guid userId, int pageNumber, int pageSize, CancellationToken cancellationToken = default!);

    void Create(Pin pin);

    void Update(Pin pin);
}