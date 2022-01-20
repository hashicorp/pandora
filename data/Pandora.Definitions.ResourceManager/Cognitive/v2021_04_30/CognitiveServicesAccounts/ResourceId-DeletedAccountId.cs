using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.CognitiveServicesAccounts;

internal class DeletedAccountId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/providers/Microsoft.CognitiveServices/locations/{location}/resourceGroups/{resourceGroupName}/deletedAccounts/{accountName}";

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
                    Name = "staticMicrosoftCognitiveServices",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.CognitiveServices"
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
                    Name = "staticDeletedAccounts",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "deletedAccounts"
                },

                new()
                {
                    Name = "accountName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

    };
}
