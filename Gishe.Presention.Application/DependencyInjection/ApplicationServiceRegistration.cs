using FluentValidation;
using Gishe.Presention.Application.Features.Users.Consumers;
using Gishe.Presention.Application.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Gishe.Presention.Application.DependencyInjection;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(
            typeof(ApplicationServiceRegistration).Assembly);

        services.AddScoped<IConsumerService, ConsumerService>();

        return services;
    }
}
