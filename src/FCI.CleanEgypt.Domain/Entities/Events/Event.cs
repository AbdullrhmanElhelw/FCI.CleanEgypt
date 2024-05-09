using FCI.CleanEgypt.Domain.Common;
using FCI.CleanEgypt.Domain.Entities.UserEvents;

namespace FCI.CleanEgypt.Domain.Entities.Events;

public sealed class Event : BaseEntity
{
    private readonly HashSet<UserEvent> _userEvents;

    private Event()
    {
        _userEvents = [];
    }

    public string Name { get; private set; }
    public DateTime Date { get; private set; }
    public string Detalis { get; private set; }

    public IReadOnlyCollection<UserEvent> UserEvents => _userEvents;

    public static Event Create(
        string name,
        DateTime date,
        string details)
    {
        return new Event
        {
            Name = name,
            Date = date,
            Detalis = details
        };
    }
}