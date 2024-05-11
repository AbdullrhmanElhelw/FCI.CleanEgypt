using FCI.CleanEgypt.Domain.Entities.Events;
using FCI.CleanEgypt.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace FCI.CleanEgypt.Application;

public interface ICleanEgyptDbContext
{
    DbSet<Event> Events { get; }
    Task<int> SaveChangesAsync();
}