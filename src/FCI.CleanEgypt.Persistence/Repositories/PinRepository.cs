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

    public async Task DeletePin(Guid pinId, CancellationToken cancellationToken = default)
    {
        var pin = await _context.Pins.FindAsync(pinId, cancellationToken);
        var deletedPin = Pin.Delete(pin);
        _context.Pins.Update(deletedPin);
    }

    /* public async Task<Pin?> FindPinAsync(string city, string street, CancellationToken cancellationToken = default) =>
         await _context.Pins
         .Where(x => x.City == city && x.Street == street)
         .FirstOrDefaultAsync(cancellationToken);*/

    public async Task<IReadOnlyCollection<Pin>> GetAllPinsAsync(Guid userId, int pageNumber, int pageSize, CancellationToken cancellationToken = default)
    {
        return await _context.Pins
            .Where(x => x.UserId == userId)
            .Select(x => Pin.GetPin(x.Id, x.TypeOfWaste, x.Address, x.Date))
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<Pin?> GetPinAsync(Guid pinId, CancellationToken cancellationToken = default!)
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