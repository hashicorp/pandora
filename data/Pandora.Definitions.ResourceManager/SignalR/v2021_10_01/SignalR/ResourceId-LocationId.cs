using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.SignalR.v2021_10_01.SignalR;

internal class LocationId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/providers/Microsoft.SignalRService/locations/{location}";

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
                    Name = "staticMicrosoftSignalRService",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.SignalRService"
                },

                new()
                {
                    Name = "staticLocations",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "locations"
                },

                new()
                {
                    Name = "location",
                    Type = ResourceIDSegmentType.UserSpecified
                },

    };
}
