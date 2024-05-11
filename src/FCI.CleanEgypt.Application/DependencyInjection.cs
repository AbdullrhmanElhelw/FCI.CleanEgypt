using System.Reflection;
using FCI.CleanEgypt.Contracts.CQRS.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FCI.CleanEgypt.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Add MediatR and register services
        services.AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        // Add logging pipeline behavior
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingPipeLineBehavior<,>));

        // Add validation pipeline behavior
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));


        // Add validators from the executing assembly
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}