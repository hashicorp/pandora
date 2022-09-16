using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.SqlPoolsReplicationLinks;

internal class ReplicationLinkId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Synapse/workspaces/{workspaceName}/sqlPools/{sqlPoolName}/replicationLinks/{linkId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftSynapse", "Microsoft.Synapse"),
        ResourceIDSegment.Static("staticWorkspaces", "workspaces"),
        ResourceIDSegment.UserSpecified("workspaceName"),
        ResourceIDSegment.Static("staticSqlPools", "sqlPools"),
        ResourceIDSegment.UserSpecified("sqlPoolName"),
        ResourceIDSegment.Static("staticReplicationLinks", "replicationLinks"),
        ResourceIDSegment.UserSpecified("linkId"),
    };
}
