using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.Regions
{
    internal class SkuId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/providers/Microsoft.EventHub/sku/{sku}";
    }
}
