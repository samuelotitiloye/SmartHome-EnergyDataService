using MediatR;

namespace EnergyDataService.Application.EnergyReadings.Queries;

public record GetEnergyReadingByIdQuery(Guid Id) : IRequest<EnergyReadingDto?>;