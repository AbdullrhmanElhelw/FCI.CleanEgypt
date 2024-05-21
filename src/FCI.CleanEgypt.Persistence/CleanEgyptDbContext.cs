using FCI.CleanEgypt.Application;
using FCI.CleanEgypt.Contracts.UnitOfWork;
using FCI.CleanEgypt.Domain.Common;
using FCI.CleanEgypt.Domain.Entities.Events;
using FCI.CleanEgypt.Domain.Entities.Pins;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FCI.CleanEgypt.Persistence;

public sealed class CleanEgyptDbContext(DbContextOptions<CleanEgyptDbContext> options)
    : IdentityDbContext<BaseIdentityEntity, IdentityRole<Guid>, Guid>(options)
        , ICleanEgyptDbContext
        , IUnitOfWork
{
    public DbSet<Event> Events => Set<Event>();

    public DbSet<Pin> Pins => Set<Pin>();

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        => await base.SaveChangesAsync(cancellationToken);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}