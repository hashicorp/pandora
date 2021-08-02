using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.Locations
{
    internal class LocationId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/providers/Microsoft.AVS/locations/{location}";
    }
}
