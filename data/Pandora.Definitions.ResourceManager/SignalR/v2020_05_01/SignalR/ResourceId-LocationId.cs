using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.SignalR.v2020_05_01.SignalR
{
    internal class LocationId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/providers/Microsoft.SignalRService/locations/{location}";
    }
}
