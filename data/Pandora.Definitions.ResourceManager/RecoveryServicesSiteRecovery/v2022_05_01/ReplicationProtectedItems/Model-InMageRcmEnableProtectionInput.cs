using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationProtectedItems;

[ValueForType("InMageRcm")]
internal class InMageRcmEnableProtectionInputModel : EnableProtectionProviderSpecificInputModel
{
    [JsonPropertyName("disksDefault")]
    public InMageRcmDisksDefaultInputModel? DisksDefault { get; set; }

    [JsonPropertyName("disksToInclude")]
    public List<InMageRcmDiskInputModel>? DisksToInclude { get; set; }

    [JsonPropertyName("fabricDiscoveryMachineId")]
    [Required]
    public string FabricDiscoveryMachineId { get; set; }

    [JsonPropertyName("licenseType")]
    public LicenseTypeConstant? LicenseType { get; set; }

    [JsonPropertyName("multiVmGroupName")]
    public string? MultiVmGroupName { get; set; }

    [JsonPropertyName("processServerId")]
    [Required]
    public string ProcessServerId { get; set; }

    [JsonPropertyName("runAsAccountId")]
    public string? RunAsAccountId { get; set; }

    [JsonPropertyName("targetAvailabilitySetId")]
    public string? TargetAvailabilitySetId { get; set; }

    [JsonPropertyName("targetAvailabilityZone")]
    public string? TargetAvailabilityZone { get; set; }

    [JsonPropertyName("targetBootDiagnosticsStorageAccountId")]
    public string? TargetBootDiagnosticsStorageAccountId { get; set; }

    [JsonPropertyName("targetNetworkId")]
    public string? TargetNetworkId { get; set; }

    [JsonPropertyName("targetProximityPlacementGroupId")]
    public string? TargetProximityPlacementGroupId { get; set; }

    [JsonPropertyName("targetResourceGroupId")]
    [Required]
    public string TargetResourceGroupId { get; set; }

    [JsonPropertyName("targetSubnetName")]
    public string? TargetSubnetName { get; set; }

    [JsonPropertyName("targetVmName")]
    public string? TargetVmName { get; set; }

    [JsonPropertyName("targetVmSize")]
    public string? TargetVmSize { get; set; }

    [JsonPropertyName("testNetworkId")]
    public string? TestNetworkId { get; set; }

    [JsonPropertyName("testSubnetName")]
    public string? TestSubnetName { get; set; }
}
