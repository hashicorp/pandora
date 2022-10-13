using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationProtectedItems;

[ValueForType("InMageAzureV2")]
internal class InMageAzureV2EnableProtectionInputModel : EnableProtectionProviderSpecificInputModel
{
    [JsonPropertyName("diskEncryptionSetId")]
    public string? DiskEncryptionSetId { get; set; }

    [JsonPropertyName("diskType")]
    public DiskAccountTypeConstant? DiskType { get; set; }

    [JsonPropertyName("disksToInclude")]
    public List<InMageAzureV2DiskInputDetailsModel>? DisksToInclude { get; set; }

    [JsonPropertyName("enableRdpOnTargetOption")]
    public string? EnableRdpOnTargetOption { get; set; }

    [JsonPropertyName("licenseType")]
    public LicenseTypeConstant? LicenseType { get; set; }

    [JsonPropertyName("logStorageAccountId")]
    public string? LogStorageAccountId { get; set; }

    [JsonPropertyName("masterTargetId")]
    public string? MasterTargetId { get; set; }

    [JsonPropertyName("multiVmGroupId")]
    public string? MultiVmGroupId { get; set; }

    [JsonPropertyName("multiVmGroupName")]
    public string? MultiVmGroupName { get; set; }

    [JsonPropertyName("processServerId")]
    public string? ProcessServerId { get; set; }

    [JsonPropertyName("runAsAccountId")]
    public string? RunAsAccountId { get; set; }

    [JsonPropertyName("seedManagedDiskTags")]
    public Dictionary<string, string>? SeedManagedDiskTags { get; set; }

    [JsonPropertyName("sqlServerLicenseType")]
    public SqlServerLicenseTypeConstant? SqlServerLicenseType { get; set; }

    [JsonPropertyName("storageAccountId")]
    public string? StorageAccountId { get; set; }

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

    [JsonPropertyName("targetVmSize")]
    public string? TargetVmSize { get; set; }

    [JsonPropertyName("targetVmTags")]
    public Dictionary<string, string>? TargetVmTags { get; set; }
}
