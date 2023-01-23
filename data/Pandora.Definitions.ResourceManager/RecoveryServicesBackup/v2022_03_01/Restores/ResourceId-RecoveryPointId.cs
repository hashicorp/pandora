using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.Restores;

internal class RecoveryPointId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.RecoveryServices/vaults/{vaultName}/backupFabrics/{backupFabricName}/protectionContainers/{protectionContainerName}/protectedItems/{protectedItemName}/recoveryPoints/{recoveryPointId}";

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
        ResourceIDSegment.Static("staticBackupFabrics", "backupFabrics"),
        ResourceIDSegment.UserSpecified("backupFabricName"),
        ResourceIDSegment.Static("staticProtectionContainers", "protectionContainers"),
        ResourceIDSegment.UserSpecified("protectionContainerName"),
        ResourceIDSegment.Static("staticProtectedItems", "protectedItems"),
        ResourceIDSegment.UserSpecified("protectedItemName"),
        ResourceIDSegment.Static("staticRecoveryPoints", "recoveryPoints"),
        ResourceIDSegment.UserSpecified("recoveryPointId"),
    };
}
