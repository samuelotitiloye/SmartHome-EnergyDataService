namespace EnergyDataService.Domain.Entities;

public sealed class EnergyReading
{
    public Guid Id { get; set; }

    public Guid DeviceId { get; set; }

    public double Watts { get; set; }

    public DateTimeOffset RecordedAtUtc { get; set; }

    public DateTimeOffset CreatedAtUtc { get; set; }
}
