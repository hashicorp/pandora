using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.CheckNameAvailabilityNamespaces
{
    internal class SubscriptionId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}";
    }
}
