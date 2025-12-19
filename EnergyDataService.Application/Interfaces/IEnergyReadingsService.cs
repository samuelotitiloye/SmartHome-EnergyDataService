using EnergyDataService.Application.Models;
using EnergyDataService.Application.Dtos;

namespace EnergyDataService.Application.Interfaces;

public interface IEnergyReadingsService
{
    Task<EnergyReadingResponse> CreateAsync(
        CreateEnergyReadingRequest request,
        CancellationToken cancellationToken = default);

    Task<PagedEnergyReadingsResponse> QueryAsync(
        EnergyReadingsQuery query,
        CancellationToken cancellationToken = default);
}
