namespace FCI.CleanEgypt.Domain.Entities.Events;

public interface IEventRepository
{
    Task<IEnumerable<Event>> GetAllEventsAsync(int pageSize, int pageNumber, string searchTerm = null);

    Task<int> EventCountAsync();

    Task<Event?> FindByIdAsync(Guid eventId, CancellationToken cancellationToken = default!);

    Task<Event?> FindEventByNameAsync(string name, CancellationToken cancellationToken = default!);

    void Add(Event @event);

    void Update(Event @event);
}