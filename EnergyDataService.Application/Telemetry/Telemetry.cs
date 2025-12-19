using System.Diagnostics;

namespace EnergyDataService.Application
{
    public static class Telemetry
    {
        public const string ActivitySourceName = "EnergyDataService";
        public static readonly ActivitySource ActivitySource = new(ActivitySourceName);
    }
}
