using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.PrivateLinkResources;

internal class PrivateLinkResourceId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AppConfiguration/configurationStores/{configStoreName}/privateLinkResources/{groupName}";

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
                    Name = "staticMicrosoftAppConfiguration",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.AppConfiguration"
                },

                new()
                {
                    Name = "staticConfigurationStores",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "configurationStores"
                },

                new()
                {
                    Name = "configStoreName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

                new()
                {
                    Name = "staticPrivateLinkResources",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "privateLinkResources"
                },

                new()
                {
                    Name = "groupName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

    };
}
