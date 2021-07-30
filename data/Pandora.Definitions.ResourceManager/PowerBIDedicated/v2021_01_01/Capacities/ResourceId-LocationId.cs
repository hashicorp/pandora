using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.Capacities
{
    internal class LocationId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/providers/Microsoft.PowerBIDedicated/locations/{location}";
    }
}
