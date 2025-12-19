using EnergyDataService.Application.Interfaces;
using EnergyDataService.Domain.Entities;
using EnergyDataService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EnergyDataService.Infrastructure.Repositories;

public sealed class EnergyReadingRepository : IEnergyReadingRepository
{
    private readonly EnergyDbContext _dbContext;

    public EnergyReadingRepository(EnergyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(EnergyReading reading, CancellationToken cancellationToken)
    {
        _dbContext.EnergyReadings.Add(reading);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task CreateAsync(EnergyReading reading, CancellationToken ct)
    {
        await _dbContext.EnergyReadings.AddAsync(reading, ct);
        await _dbContext.SaveChangesAsync(ct);
    }

    public async Task<EnergyReading?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return await _dbContext.EnergyReadings
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id, ct);
    }
}