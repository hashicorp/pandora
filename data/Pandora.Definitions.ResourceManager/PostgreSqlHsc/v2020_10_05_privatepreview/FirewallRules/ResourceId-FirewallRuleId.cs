using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSqlHsc.v2020_10_05_privatepreview.FirewallRules;

internal class FirewallRuleId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DBForPostgreSql/serverGroupsv2/{serverGroupName}/firewallRules/{firewallRuleName}";

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

                new()
                {
                    Name = "staticFirewallRules",
                    Type = ResourceIDSegmentType.Static,
                    FixedValue = "firewallRules"
                },

                new()
                {
                    Name = "firewallRuleName",
                    Type = ResourceIDSegmentType.UserSpecified
                },

    };
}
