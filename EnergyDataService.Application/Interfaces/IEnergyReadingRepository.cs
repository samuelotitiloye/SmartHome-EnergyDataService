using EnergyDataService.Domain.Entities;

namespace EnergyDataService.Application.Interfaces;

public interface IEnergyReadingRepository
{
    Task AddAsync(EnergyReading reading, CancellationToken cancellationToken);
    Task CreateAsync(EnergyReading reading, CancellationToken ct);
    Task<EnergyReading?> GetByIdAsync(Guid id, CancellationToken ct);
}