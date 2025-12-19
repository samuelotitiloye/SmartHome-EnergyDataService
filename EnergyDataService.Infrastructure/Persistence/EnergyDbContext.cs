using EnergyDataService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnergyDataService.Infrastructure.Persistence;

public sealed class EnergyDbContext : DbContext
{
    public EnergyDbContext(DbContextOptions<EnergyDbContext> options)
    : base (options)
    {

    }
    
    public DbSet<EnergyReading> EnergyReadings => Set<EnergyReading>();
}