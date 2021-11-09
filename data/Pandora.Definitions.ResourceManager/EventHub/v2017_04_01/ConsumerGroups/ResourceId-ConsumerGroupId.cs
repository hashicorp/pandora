using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.ConsumerGroups
{
    internal class ConsumerGroupId : ResourceID
    {
        public string? CommonAlias => null;

        public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/eventhubs/{eventHubName}/consumerGroups/{consumerGroupName}";

        public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
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
                    Name = "resourceGroups",
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
                    Name = "providers",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "providers"
                },

                new()
                {
                    Name = "microsoftEventHub",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.EventHub"
                },

                new()
                {
                    Name = "namespaces",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "namespaces"
                },

                new()
                {
                    Name = "namespaceName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "eventhubs",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "eventhubs"
                },

                new()
                {
                    Name = "eventHubName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "consumerGroups",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "consumerGroups"
                },

                new()
                {
                    Name = "consumerGroupName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

        };
    }
}
