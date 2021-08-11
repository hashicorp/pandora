using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
    internal class SubscriptionId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}";
    }
}
