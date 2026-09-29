using Gishe.Presentation.Infrastructure.Repositories;
using Gishe.Presention.Application.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Gishe.Presentation.Infrastructure.DependencyInjection;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddScoped<IConsumerRepository, ConsumerRepository>();

        return services;
    }
}