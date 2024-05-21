using FCI.CleanEgypt.Domain.Entities.Events;
using Microsoft.EntityFrameworkCore;

namespace FCI.CleanEgypt.Persistence.Repositories;

public class EventRepository : IEventRepository
{
    private readonly CleanEgyptDbContext _context;

    public EventRepository(CleanEgyptDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Event>> GetAllEventsAsync(int pageSize, int pageNumber, string? searchTerm = null)
    {
        var events = _context.Events.AsQueryable();

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            var searchTermLower = searchTerm.ToLowerInvariant();
            events = events.Where(x => x.Name.ToLower().Contains(searchTermLower) ||
                                       x.Detalis.ToLower().Contains(searchTermLower));
        }

        return await events
            .OrderBy(x => x.Name)
            .Skip(pageSize * (pageNumber - 1))
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<int> EventCountAsync()
    {
        return await _context
            .Events
            .CountAsync();
    }

    public async Task<Event?> FindByIdAsync(Guid eventId, CancellationToken cancellationToken = default!)
    {
        var @event = await _context
            .Events
            .FindAsync(new object?[] { eventId, cancellationToken }, cancellationToken);

        return @event;
    }

    public async Task<Event?> FindEventByNameAsync(string name, CancellationToken cancellationToken = default!)
    {
        var @event = await _context
            .Events
            .Where(x => x.Name == name)
            .FirstOrDefaultAsync(cancellationToken);

        return @event;
    }

    public void Add(Event @event)
    {
        _context.Events.Add(@event);
    }

    public void Update(Event @event) =>
        _context.Events.Update(@event);
}