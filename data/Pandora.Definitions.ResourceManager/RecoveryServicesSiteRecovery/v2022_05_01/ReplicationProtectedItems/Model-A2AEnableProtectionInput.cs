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
internal class A2AEnableProtectionInputModel : EnableProtectionProviderSpecificInputModel
{
    [JsonPropertyName("diskEncryptionInfo")]
    public DiskEncryptionInfoModel? DiskEncryptionInfo { get; set; }

    [JsonPropertyName("fabricObjectId")]
    [Required]
    public string FabricObjectId { get; set; }

    [JsonPropertyName("multiVmGroupId")]
    public string? MultiVmGroupId { get; set; }

    [JsonPropertyName("multiVmGroupName")]
    public string? MultiVmGroupName { get; set; }

    [JsonPropertyName("recoveryAvailabilitySetId")]
    public string? RecoveryAvailabilitySetId { get; set; }

    [JsonPropertyName("recoveryAvailabilityZone")]
    public string? RecoveryAvailabilityZone { get; set; }

    [JsonPropertyName("recoveryAzureNetworkId")]
    public string? RecoveryAzureNetworkId { get; set; }

    [JsonPropertyName("recoveryBootDiagStorageAccountId")]
    public string? RecoveryBootDiagStorageAccountId { get; set; }

    [JsonPropertyName("recoveryCapacityReservationGroupId")]
    public string? RecoveryCapacityReservationGroupId { get; set; }

    [JsonPropertyName("recoveryCloudServiceId")]
    public string? RecoveryCloudServiceId { get; set; }

    [JsonPropertyName("recoveryContainerId")]
    public string? RecoveryContainerId { get; set; }

    [JsonPropertyName("recoveryExtendedLocation")]
    public CustomTypes.EdgeZone? RecoveryExtendedLocation { get; set; }

    [JsonPropertyName("recoveryProximityPlacementGroupId")]
    public string? RecoveryProximityPlacementGroupId { get; set; }

    [JsonPropertyName("recoveryResourceGroupId")]
    public string? RecoveryResourceGroupId { get; set; }

    [JsonPropertyName("recoverySubnetName")]
    public string? RecoverySubnetName { get; set; }

    [JsonPropertyName("recoveryVirtualMachineScaleSetId")]
    public string? RecoveryVirtualMachineScaleSetId { get; set; }

    [JsonPropertyName("vmDisks")]
    public List<A2AVmDiskInputDetailsModel>? VmDisks { get; set; }

    [JsonPropertyName("vmManagedDisks")]
    public List<A2AVmManagedDiskInputDetailsModel>? VmManagedDisks { get; set; }
}
