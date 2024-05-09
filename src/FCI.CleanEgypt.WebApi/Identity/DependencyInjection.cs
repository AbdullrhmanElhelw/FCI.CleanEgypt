using FCI.CleanEgypt.Domain.Common;
using FCI.CleanEgypt.Domain.Entities.Admins;
using FCI.CleanEgypt.Domain.Entities.Users;
using FCI.CleanEgypt.Persistence;
using Microsoft.AspNetCore.Identity;

namespace FCI.CleanEgypt.WebApi.Identity;

public static class DependencyInjection
{
    public static IServiceCollection AddIdentityUsers(this IServiceCollection services)
    {
        services.AddIdentity<BaseIdentityEntity, IdentityRole<Guid>>(op =>
            {
                op.Password.RequireDigit = true;
                op.Password.RequireLowercase = true;
                op.Password.RequireNonAlphanumeric = true;
                op.Password.RequireUppercase = true;
                op.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                op.Lockout.MaxFailedAccessAttempts = 5;
                op.SignIn.RequireConfirmedPhoneNumber = true;
            })
            .AddEntityFrameworkStores<CleanEgyptDbContext>()
            .AddDefaultTokenProviders();

        services.AddIdentityCore<Admin>()
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<CleanEgyptDbContext>()
            .AddDefaultTokenProviders();

        services.AddIdentityCore<User>()
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<CleanEgyptDbContext>()
            .AddDefaultTokenProviders();
        return services;
    }
}