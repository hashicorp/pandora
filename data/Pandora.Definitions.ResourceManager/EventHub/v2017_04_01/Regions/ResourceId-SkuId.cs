using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.Regions;

internal class SkuId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/providers/Microsoft.EventHub/sku/{sku}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
                new()
                {
                    Name = "staticSubscriptions",
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
                    Name = "staticProviders",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "providers"
                },

                new()
                {
                    Name = "staticMicrosoftEventHub",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.EventHub"
                },

                new()
                {
                    Name = "staticSku",
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
