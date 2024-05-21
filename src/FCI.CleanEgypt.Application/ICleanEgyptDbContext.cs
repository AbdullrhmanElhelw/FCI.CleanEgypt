using FCI.CleanEgypt.Domain.Entities.Events;
using FCI.CleanEgypt.Domain.Entities.Pins;
using Microsoft.EntityFrameworkCore;

namespace FCI.CleanEgypt.Application;

public interface ICleanEgyptDbContext
{
    DbSet<Pin> Pins { get; }
    DbSet<Event> Events { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default!);
}