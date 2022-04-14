using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.SignalR.v2021_10_01.SignalR;

internal class SharedPrivateLinkResourceId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.SignalRService/signalR/{resourceName}/sharedPrivateLinkResources/{sharedPrivateLinkResourceName}";

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
                    Name = "staticMicrosoftSignalRService",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.SignalRService"
                },

                new()
                {
                    Name = "staticSignalR",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "signalR"
                },

                new()
                {
                    Name = "resourceName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "staticSharedPrivateLinkResources",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "sharedPrivateLinkResources"
                },

                new()
                {
                    Name = "sharedPrivateLinkResourceName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

    };
}
