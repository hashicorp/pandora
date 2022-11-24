using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectedItems;

[ValueForType("HyperVReplicaAzure")]
internal class HyperVReplicaAzureEnableProtectionInputModel : EnableProtectionProviderSpecificInputModel
{
    [JsonPropertyName("diskEncryptionSetId")]
    public string? DiskEncryptionSetId { get; set; }

    [JsonPropertyName("diskType")]
    public DiskAccountTypeConstant? DiskType { get; set; }

    [JsonPropertyName("disksToInclude")]
    public List<string>? DisksToInclude { get; set; }

    [JsonPropertyName("disksToIncludeForManagedDisks")]
    public List<HyperVReplicaAzureDiskInputDetailsModel>? DisksToIncludeForManagedDisks { get; set; }

    [JsonPropertyName("enableRdpOnTargetOption")]
    public string? EnableRdpOnTargetOption { get; set; }

    [JsonPropertyName("hvHostVmId")]
    public string? HvHostVmId { get; set; }

    [JsonPropertyName("licenseType")]
    public LicenseTypeConstant? LicenseType { get; set; }

    [JsonPropertyName("logStorageAccountId")]
    public string? LogStorageAccountId { get; set; }

    [JsonPropertyName("osType")]
    public string? OsType { get; set; }

    [JsonPropertyName("seedManagedDiskTags")]
    public Dictionary<string, string>? SeedManagedDiskTags { get; set; }

    [JsonPropertyName("sqlServerLicenseType")]
    public SqlServerLicenseTypeConstant? SqlServerLicenseType { get; set; }

    [JsonPropertyName("targetAvailabilitySetId")]
    public string? TargetAvailabilitySetId { get; set; }

    [JsonPropertyName("targetAvailabilityZone")]
    public string? TargetAvailabilityZone { get; set; }

    [JsonPropertyName("targetAzureNetworkId")]
    public string? TargetAzureNetworkId { get; set; }

    [JsonPropertyName("targetAzureSubnetId")]
    public string? TargetAzureSubnetId { get; set; }

    [JsonPropertyName("targetAzureV1ResourceGroupId")]
    public string? TargetAzureV1ResourceGroupId { get; set; }

    [JsonPropertyName("targetAzureV2ResourceGroupId")]
    public string? TargetAzureV2ResourceGroupId { get; set; }

    [JsonPropertyName("targetAzureVmName")]
    public string? TargetAzureVmName { get; set; }

    [JsonPropertyName("targetManagedDiskTags")]
    public Dictionary<string, string>? TargetManagedDiskTags { get; set; }

    [JsonPropertyName("targetNicTags")]
    public Dictionary<string, string>? TargetNicTags { get; set; }

    [JsonPropertyName("targetProximityPlacementGroupId")]
    public string? TargetProximityPlacementGroupId { get; set; }

    [JsonPropertyName("targetStorageAccountId")]
    public string? TargetStorageAccountId { get; set; }

    [JsonPropertyName("targetVmSize")]
    public string? TargetVmSize { get; set; }

    [JsonPropertyName("targetVmTags")]
    public Dictionary<string, string>? TargetVmTags { get; set; }

    [JsonPropertyName("useManagedDisks")]
    public string? UseManagedDisks { get; set; }

    [JsonPropertyName("useManagedDisksForReplication")]
    public string? UseManagedDisksForReplication { get; set; }

    [JsonPropertyName("vhdId")]
    public string? VhdId { get; set; }

    [JsonPropertyName("vmName")]
    public string? VirtualMachineName { get; set; }
}
