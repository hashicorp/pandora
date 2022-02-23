using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.DeletedAccounts;

internal class DeletedAccountId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/providers/Microsoft.Storage/locations/{location}/deletedAccounts/{deletedAccountName}";

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
                    Name = "staticMicrosoftStorage",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.Storage"
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

                new()
                {
                    Name = "staticDeletedAccounts",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "deletedAccounts"
                },

                new()
                {
                    Name = "deletedAccountName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

    };
}
