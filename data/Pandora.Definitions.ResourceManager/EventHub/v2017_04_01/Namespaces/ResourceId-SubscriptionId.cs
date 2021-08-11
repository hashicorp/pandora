using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.Namespaces
{
    internal class SubscriptionId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}";
    }
}
