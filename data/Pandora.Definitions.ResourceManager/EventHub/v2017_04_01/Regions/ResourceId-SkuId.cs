using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.Regions
{
    internal class SkuId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/providers/Microsoft.EventHub/sku/{sku}";
    }
}
