using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01.ConsumerGroups;

internal class ConsumerGroupId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventHub/namespaces/{namespaceName}/eventhubs/{eventHubName}/consumerGroups/{consumerGroupName}";

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
                    Name = "staticMicrosoftEventHub",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.EventHub"
                },

                new()
                {
                    Name = "staticNamespaces",
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
                    Name = "staticEventhubs",
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
                    Name = "staticConsumerGroups",
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
