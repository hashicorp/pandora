using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.PrivateLinkResources
{
    internal class ProviderId : ResourceID
    {
        public string? CommonAlias => null;

        public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/{parentType}/{parentName}";

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
                    Name = "staticResourceGroups",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "resourceGroups"
                },

                new()
                {
                    Name = "resourceGroupName",
                    Type = ResourceIDSegmentType.ResourceGroup
                },

                new()
                {
                    Name = "staticProviders",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "providers"
                },

                new()
                {
                    Name = "staticMicrosoftEventGrid",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.EventGrid"
                },

                new()
                {
                    Name = "parentType",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "parentName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

        };
    }
}
