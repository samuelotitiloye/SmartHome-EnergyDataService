using EnergyDataService.Application.Interfaces;
using EnergyDataService.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EnergyDataService.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IEnergyReadingsService, EnergyReadingsService>();
        return services;

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));
    }


}
