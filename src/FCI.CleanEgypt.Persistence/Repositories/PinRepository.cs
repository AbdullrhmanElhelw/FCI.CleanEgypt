using FCI.CleanEgypt.Application;
using FCI.CleanEgypt.Domain.Entities.Pins;
using Microsoft.EntityFrameworkCore;

namespace FCI.CleanEgypt.Persistence.Repositories;

public class PinRepository : IPinRepository
{
    private readonly ICleanEgyptDbContext _context;

    public PinRepository(ICleanEgyptDbContext context)
    {
        _context = context;
    }

    public void Create(Pin pin)
        => _context.Pins.Add(pin);

    public async Task<IReadOnlyCollection<Pin>> GetAllPinsAsync(Guid userId, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
    {
        return await _context.Pins
            .Where(x => x.UserId == userId)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<Pin?> GetPin(Guid pinId, CancellationToken cancellationToken = default!)
    {
        return await _context.Pins
            .FindAsync(pinId, cancellationToken);
    }

    public async Task<int> GetPinCountAsync(CancellationToken cancellationToken = default)
        => await _context.Pins.CountAsync(cancellationToken: cancellationToken);

    public Task<int> GetPinCountAsync(Guid userId, CancellationToken cancellationToken = default)
        => _context.Pins
        .Where(x => x.UserId == userId)
        .CountAsync(cancellationToken);

    public void Update(Pin pin)
        => _context.Pins.Update(pin);
}