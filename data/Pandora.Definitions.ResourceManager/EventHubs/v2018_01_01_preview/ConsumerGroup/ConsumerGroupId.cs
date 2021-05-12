using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHubs.v2018_01_01_preview.ConsumerGroup
{
    internal class ConsumerGroupId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.EventHub/namespaces/{namespaces}/eventhubs/{eventHub}/consumerGroups/{consumerGroup}";
    }
}