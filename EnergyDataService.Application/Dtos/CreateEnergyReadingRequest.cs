namespace EnergyDataService.Application.Dtos;

public sealed class CreateEnergyReadingRequest
{
    public Guid DeviceId { get; init; }
    public double Watts { get; init; }
    public DateTimeOffset RecordedAtUtc { get; init; }
}
