using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Containers;

internal class ContainerId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataBoxEdge/dataBoxEdgeDevices/{dataBoxEdgeDeviceName}/storageAccounts/{storageAccountName}/containers/{containerName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftDataBoxEdge", "Microsoft.DataBoxEdge"),
        ResourceIDSegment.Static("staticDataBoxEdgeDevices", "dataBoxEdgeDevices"),
        ResourceIDSegment.UserSpecified("dataBoxEdgeDeviceName"),
        ResourceIDSegment.Static("staticStorageAccounts", "storageAccounts"),
        ResourceIDSegment.UserSpecified("storageAccountName"),
        ResourceIDSegment.Static("staticContainers", "containers"),
        ResourceIDSegment.UserSpecified("containerName"),
    };
}
