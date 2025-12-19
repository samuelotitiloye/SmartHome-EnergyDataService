namespace EnergyDataService.Application.Dtos;

public sealed class EnergyReadingResponse
{
    public Guid Id { get; init; }
    public Guid DeviceId { get; init; }
    public double Watts { get; init; }
    public DateTimeOffset RecordedAtUtc { get; init; }
    public DateTimeOffset CreatedAtUtc { get; init; }
}
