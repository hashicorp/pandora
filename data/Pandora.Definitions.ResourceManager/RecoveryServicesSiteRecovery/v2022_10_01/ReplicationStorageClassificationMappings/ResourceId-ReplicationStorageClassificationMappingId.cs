using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationStorageClassificationMappings;

internal class ReplicationStorageClassificationMappingId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/replicationFabrics/{replicationFabricName}/replicationStorageClassifications/{replicationStorageClassificationName}/replicationStorageClassificationMappings/{replicationStorageClassificationMappingName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticSubscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("staticResourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroupName"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftRecoveryServices", "Microsoft.RecoveryServices"),
        ResourceIDSegment.Static("staticVaults", "vaults"),
        ResourceIDSegment.UserSpecified("vaultName"),
        ResourceIDSegment.Static("staticReplicationFabrics", "replicationFabrics"),
        ResourceIDSegment.UserSpecified("replicationFabricName"),
        ResourceIDSegment.Static("staticReplicationStorageClassifications", "replicationStorageClassifications"),
        ResourceIDSegment.UserSpecified("replicationStorageClassificationName"),
        ResourceIDSegment.Static("staticReplicationStorageClassificationMappings", "replicationStorageClassificationMappings"),
        ResourceIDSegment.UserSpecified("replicationStorageClassificationMappingName"),
    };
}
