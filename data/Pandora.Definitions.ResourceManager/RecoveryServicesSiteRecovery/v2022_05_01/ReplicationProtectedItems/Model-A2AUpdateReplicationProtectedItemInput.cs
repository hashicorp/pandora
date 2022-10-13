using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationProtectedItems;

[ValueForType("A2A")]
internal class A2AUpdateReplicationProtectedItemInputModel : UpdateReplicationProtectedItemProviderInputModel
{
    [JsonPropertyName("diskEncryptionInfo")]
    public DiskEncryptionInfoModel? DiskEncryptionInfo { get; set; }

    [JsonPropertyName("managedDiskUpdateDetails")]
    public List<A2AVmManagedDiskUpdateDetailsModel>? ManagedDiskUpdateDetails { get; set; }

    [JsonPropertyName("recoveryBootDiagStorageAccountId")]
    public string? RecoveryBootDiagStorageAccountId { get; set; }

    [JsonPropertyName("recoveryCapacityReservationGroupId")]
    public string? RecoveryCapacityReservationGroupId { get; set; }

    [JsonPropertyName("recoveryCloudServiceId")]
    public string? RecoveryCloudServiceId { get; set; }

    [JsonPropertyName("recoveryProximityPlacementGroupId")]
    public string? RecoveryProximityPlacementGroupId { get; set; }

    [JsonPropertyName("recoveryResourceGroupId")]
    public string? RecoveryResourceGroupId { get; set; }

    [JsonPropertyName("recoveryVirtualMachineScaleSetId")]
    public string? RecoveryVirtualMachineScaleSetId { get; set; }

    [JsonPropertyName("tfoAzureVMName")]
    public string? TfoAzureVMName { get; set; }
}
