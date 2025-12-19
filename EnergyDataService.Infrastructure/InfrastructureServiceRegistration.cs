using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using EnergyDataService.Application.Interfaces;
using EnergyDataService.Infrastructure.Repositories;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IEnergyReadingRepository, EnergyReadingRepository>();

        return services;
    }
}
