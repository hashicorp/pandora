using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2023_01_01.BlobContainers;

internal class StorageContainerId : ResourceID
{
    public string? CommonAlias => "StorageContainer";

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{storageAccountName}/blobServices/default/containers/{containerName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("subscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("resourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("providers", "providers"),
        ResourceIDSegment.ResourceProvider("resourceProvider", "Microsoft.Storage"),
        ResourceIDSegment.Static("storageAccounts", "storageAccounts"),
        ResourceIDSegment.UserSpecified("storageAccountName"),
        ResourceIDSegment.Static("blobServices", "blobServices"),
        ResourceIDSegment.Static("default", "default"),
        ResourceIDSegment.Static("containers", "containers"),
        ResourceIDSegment.UserSpecified("containerName"),
    };
}
