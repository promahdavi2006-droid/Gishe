using Gishe.Presentation.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Gishe.Presention.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IEventService, EventService>();

        services.AddScoped<ISessionService, SessionService>();

        services.AddScoped<IVenueService, VenueService>();

        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(
                typeof(DependencyInjection).Assembly);
        });

        return services;
    }
}