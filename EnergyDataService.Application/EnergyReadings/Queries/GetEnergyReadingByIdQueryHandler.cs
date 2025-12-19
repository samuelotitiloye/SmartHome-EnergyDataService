using MediatR;
using EnergyDataService.Application.Interfaces;

namespace EnergyDataService.Application.EnergyReadings.Queries;

public class GetEnergyReadingByIdQueryHandler : IRequestHandler<GetEnergyReadingByIdQuery, EnergyReadingDto>
{
    private readonly IEnergyReadingRepository _repository;

    public GetEnergyReadingByIdQueryHandler(IEnergyReadingRepository repository)
    {
        _repository = repository;
    }

    public async Task<EnergyReadingDto?> Handle(GetEnergyReadingByIdQuery request, CancellationToken ct)
    {
        var reading = await _repository.GetByIdAsync(request.Id, ct);

        if (reading is null)
            return null;

            return new EnergyReadingDto(
                reading.Id,
                reading.DeviceId,
                reading.Watts,
                reading.RecordedAtUtc
            );
    }
}