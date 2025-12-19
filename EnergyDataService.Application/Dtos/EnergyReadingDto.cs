public record EnergyReadingDto(
    Guid Id,
    Guid DeviceId,
    double Watts,
    DateTimeOffset RecordedAt
);