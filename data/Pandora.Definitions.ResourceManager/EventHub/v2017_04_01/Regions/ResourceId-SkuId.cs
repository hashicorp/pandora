using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.Regions
{
    internal class SkuId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/providers/Microsoft.EventHub/sku/{sku}";

        public List<ResourceIDSegment> Segments()
        {
            return new List<ResourceIDSegment>
            {
                new()
                {
                    Name = "subscriptions",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "subscriptions"
                },

                new()
                {
                    Name = "subscriptionId",
                    Type = ResourceIDSegmentType.SubscriptionId
                },

                new()
                {
                    Name = "providers",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "providers"
                },

                new()
                {
                    Name = "microsoftEventHub",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "Microsoft.EventHub"
                },

                new()
                {
                    Name = "sku",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "sku"
                },

                new()
                {
                    Name = "sku",
                    Type = ResourceIDSegmentType.UserSpecified
                },

            };
        }
    }
}
