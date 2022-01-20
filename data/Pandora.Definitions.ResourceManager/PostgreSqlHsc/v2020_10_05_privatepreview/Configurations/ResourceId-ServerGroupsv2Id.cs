using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.PostgreSqlHsc.v2020_10_05_privatepreview.Configurations;

internal class ServerGroupsv2Id : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBForPostgreSql/serverGroupsv2/{serverGroupName}";

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
                    Name = "staticMicrosoftDBForPostgreSql",
                    Type = ResourceIDSegmentType.ResourceProvider,
                    FixedValue = "Microsoft.DBForPostgreSql"
                },

                new()
                {
                    Name = "staticServerGroupsv2",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "serverGroupsv2"
                },

                new()
                {
                    Name = "serverGroupName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

    };
}
