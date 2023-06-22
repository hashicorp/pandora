using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_04_02_preview.ResolvePrivateLinkServiceId;

internal class KubernetesClusterId : ResourceID
{
    public string? CommonAlias => "KubernetesCluster";

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ContainerService/managedClusters/{managedClusterName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("subscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("resourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("providers", "providers"),
        ResourceIDSegment.ResourceProvider("resourceProvider", "Microsoft.ContainerService"),
        ResourceIDSegment.Static("managedClusters", "managedClusters"),
        ResourceIDSegment.UserSpecified("managedClusterName"),
    };
}
