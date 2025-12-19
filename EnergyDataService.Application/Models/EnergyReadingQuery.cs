namespace EnergyDataService.Application.Models;

public sealed class EnergyReadingsQuery
{
    public Guid DeviceId { get; init; }

    public DateTimeOffset? FromUtc { get; init; }
    public DateTimeOffset? ToUtc { get; init; }
    
    public int Page { get; init; } = 1;
    public int PageSize { get; init; } = 50;
}