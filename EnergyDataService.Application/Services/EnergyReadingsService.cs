using EnergyDataService.Application.Dtos;
using EnergyDataService.Application.Exceptions;
using EnergyDataService.Application.Interfaces;
using EnergyDataService.Application.Models;
using EnergyDataService.Domain.Entities;


namespace EnergyDataService.Application.Services;

public sealed class EnergyReadingsService : IEnergyReadingsService
{
    private readonly IEnergyReadingRepository _repository;

    public EnergyReadingsService(IEnergyReadingRepository repository)
    {
        _repository = repository;
    }

    public async Task<EnergyReadingResponse> CreateAsync(
        CreateEnergyReadingRequest request,
        CancellationToken cancellationToken = default)
    {
        // 1) Validation (explicit, v0)
        if (request.DeviceId == Guid.Empty)
            throw new InvalidEnergyReadingException("DeviceId must be provided.");

        if (request.Watts < 0)
            throw new InvalidEnergyReadingException("Watts must be greater than or equal to zero.");

        if (request.RecordedAtUtc == default)
            throw new InvalidEnergyReadingException("RecordedAtUtc must be provided.");

        // 2) Create domain entity
        var entity = new EnergyReading
        {
            Id = Guid.NewGuid(),
            DeviceId = request.DeviceId,
            Watts = request.Watts,
            RecordedAtUtc = request.RecordedAtUtc,
            CreatedAtUtc = DateTimeOffset.UtcNow
        };

        // 3) Persist
        await _repository.AddAsync(entity, cancellationToken);

        // 4) Map to response
        return new EnergyReadingResponse
        {
            Id = entity.Id,
            DeviceId = entity.DeviceId,
            Watts = entity.Watts,
            RecordedAtUtc = entity.RecordedAtUtc,
            CreatedAtUtc = entity.CreatedAtUtc
        };
    }

    public Task<PagedEnergyReadingsResponse> QueryAsync(
        EnergyReadingsQuery query,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
