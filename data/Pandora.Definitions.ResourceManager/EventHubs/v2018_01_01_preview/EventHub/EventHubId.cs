using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHubs.v2018_01_01_preview.EventHub
{
    internal class EventHubId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.EventHub/namespaces/{namespace}/eventhubs/{eventHub}";
    }
}