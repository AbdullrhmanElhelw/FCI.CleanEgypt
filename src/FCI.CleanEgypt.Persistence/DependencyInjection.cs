using FCI.CleanEgypt.Application;
using FCI.CleanEgypt.Contracts.UnitOfWork;
using FCI.CleanEgypt.Domain.Entities.Events;
using FCI.CleanEgypt.Domain.Entities.Pins;
using FCI.CleanEgypt.Persistence.Infrastructure;
using FCI.CleanEgypt.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FCI.CleanEgypt.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionString.SettingsKey)
                               ?? throw new ArgumentNullException(nameof(ConnectionString),
                                   "Connection String Not Found!!");

        services.AddSingleton(new ConnectionString(connectionString));

        services.AddDbContext<CleanEgyptDbContext>(op => { op.UseSqlServer(connectionString); });

        services.AddScoped<ICleanEgyptDbContext>(sp =>
            sp.GetRequiredService<CleanEgyptDbContext>());

        services.AddScoped<IUnitOfWork>(sp =>
            sp.GetRequiredService<CleanEgyptDbContext>());

        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IPinRepository, PinRepository>();

        return services;
    }
}