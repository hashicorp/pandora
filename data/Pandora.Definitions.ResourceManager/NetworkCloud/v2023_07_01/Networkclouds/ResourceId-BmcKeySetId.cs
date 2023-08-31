using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;

internal class BmcKeySetId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetworkCloud/clusters/{clusterName}/bmcKeySets/{bmcKeySetName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftNetworkCloud", "Microsoft.NetworkCloud"),
        ResourceIDSegment.Static("staticClusters", "clusters"),
        ResourceIDSegment.UserSpecified("clusterName"),
        ResourceIDSegment.Static("staticBmcKeySets", "bmcKeySets"),
        ResourceIDSegment.UserSpecified("bmcKeySetName"),
    };
}
