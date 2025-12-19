using System.Diagnostics;

namespace EnergyDataService.Api.Telemetry
{
    internal static class Telemetry
    {
        public const string ActivitySourceName = "EnergyDataService";
        public static readonly ActivitySource ActivitySource = new(ActivitySourceName);
    }
}
