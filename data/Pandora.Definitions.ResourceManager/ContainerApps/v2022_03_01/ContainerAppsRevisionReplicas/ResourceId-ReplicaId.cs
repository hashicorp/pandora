using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_03_01.ContainerAppsRevisionReplicas;

internal class ReplicaId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.App/containerApps/{containerAppName}/revisions/{revisionName}/replicas/{replicaName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftApp", "Microsoft.App"),
        ResourceIDSegment.Static("staticContainerApps", "containerApps"),
        ResourceIDSegment.UserSpecified("containerAppName"),
        ResourceIDSegment.Static("staticRevisions", "revisions"),
        ResourceIDSegment.UserSpecified("revisionName"),
        ResourceIDSegment.Static("staticReplicas", "replicas"),
        ResourceIDSegment.UserSpecified("replicaName"),
    };
}
