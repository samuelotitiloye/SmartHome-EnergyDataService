using EnergyDataService.Application.Dtos;

namespace EnergyDataService.Application.Dtos;

public sealed class PagedEnergyReadingsResponse
{
    public IReadOnlyList<EnergyReadingResponse> Items { get; init; } = [];
    public int Page { get; init; }
    public int PageSize { get; init; }
    public int TotalCount { get; init; }
}
