using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_02_01.ReplicationProtectionContainerMappings;

internal class ReplicationProtectionContainerMappingId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/replicationFabrics/{replicationFabricName}/replicationProtectionContainers/{replicationProtectionContainerName}/replicationProtectionContainerMappings/{replicationProtectionContainerMappingName}";

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
        ResourceIDSegment.Static("staticReplicationProtectionContainers", "replicationProtectionContainers"),
        ResourceIDSegment.UserSpecified("replicationProtectionContainerName"),
        ResourceIDSegment.Static("staticReplicationProtectionContainerMappings", "replicationProtectionContainerMappings"),
        ResourceIDSegment.UserSpecified("replicationProtectionContainerMappingName"),
    };
}
