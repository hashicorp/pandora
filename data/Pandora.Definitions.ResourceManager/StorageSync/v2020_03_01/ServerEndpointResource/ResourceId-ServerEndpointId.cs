using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01.ServerEndpointResource;

internal class ServerEndpointId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.StorageSync/storageSyncServices/{storageSyncServiceName}/syncGroups/{syncGroupName}/serverEndpoints/{serverEndpointName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftStorageSync", "Microsoft.StorageSync"),
        ResourceIDSegment.Static("staticStorageSyncServices", "storageSyncServices"),
        ResourceIDSegment.UserSpecified("storageSyncServiceName"),
        ResourceIDSegment.Static("staticSyncGroups", "syncGroups"),
        ResourceIDSegment.UserSpecified("syncGroupName"),
        ResourceIDSegment.Static("staticServerEndpoints", "serverEndpoints"),
        ResourceIDSegment.UserSpecified("serverEndpointName"),
    };
}
