using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2021_10_01.Volumes;


internal class VolumePropertiesModel
{
    [JsonPropertyName("avsDataStore")]
    public AvsDataStoreConstant? AvsDataStore { get; set; }

    [JsonPropertyName("backupId")]
    public string? BackupId { get; set; }

    [JsonPropertyName("baremetalTenantId")]
    public string? BaremetalTenantId { get; set; }

    [JsonPropertyName("capacityPoolResourceId")]
    public string? CapacityPoolResourceId { get; set; }

    [JsonPropertyName("cloneProgress")]
    public int? CloneProgress { get; set; }

    [JsonPropertyName("coolAccess")]
    public bool? CoolAccess { get; set; }

    [JsonPropertyName("coolnessPeriod")]
    public int? CoolnessPeriod { get; set; }

    [JsonPropertyName("creationToken")]
    [Required]
    public string CreationToken { get; set; }

    [JsonPropertyName("dataProtection")]
    public VolumePropertiesDataProtectionModel? DataProtection { get; set; }

    [JsonPropertyName("defaultGroupQuotaInKiBs")]
    public int? DefaultGroupQuotaInKiBs { get; set; }

    [JsonPropertyName("defaultUserQuotaInKiBs")]
    public int? DefaultUserQuotaInKiBs { get; set; }

    [JsonPropertyName("enableSubvolumes")]
    public EnableSubvolumesConstant? EnableSubvolumes { get; set; }

    [JsonPropertyName("encryptionKeySource")]
    public string? EncryptionKeySource { get; set; }

    [JsonPropertyName("exportPolicy")]
    public VolumePropertiesExportPolicyModel? ExportPolicy { get; set; }

    [JsonPropertyName("fileSystemId")]
    public string? FileSystemId { get; set; }

    [JsonPropertyName("isDefaultQuotaEnabled")]
    public bool? IsDefaultQuotaEnabled { get; set; }

    [JsonPropertyName("isRestoring")]
    public bool? IsRestoring { get; set; }

    [JsonPropertyName("kerberosEnabled")]
    public bool? KerberosEnabled { get; set; }

    [JsonPropertyName("ldapEnabled")]
    public bool? LdapEnabled { get; set; }

    [JsonPropertyName("maximumNumberOfFiles")]
    public int? MaximumNumberOfFiles { get; set; }

    [JsonPropertyName("mountTargets")]
    public List<MountTargetPropertiesModel>? MountTargets { get; set; }

    [JsonPropertyName("networkFeatures")]
    public NetworkFeaturesConstant? NetworkFeatures { get; set; }

    [JsonPropertyName("networkSiblingSetId")]
    public string? NetworkSiblingSetId { get; set; }

    [JsonPropertyName("placementRules")]
    public List<PlacementKeyValuePairsModel>? PlacementRules { get; set; }

    [JsonPropertyName("protocolTypes")]
    public List<string>? ProtocolTypes { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("proximityPlacementGroup")]
    public string? ProximityPlacementGroup { get; set; }

    [JsonPropertyName("securityStyle")]
    public SecurityStyleConstant? SecurityStyle { get; set; }

    [JsonPropertyName("serviceLevel")]
    public ServiceLevelConstant? ServiceLevel { get; set; }

    [JsonPropertyName("smbContinuouslyAvailable")]
    public bool? SmbContinuouslyAvailable { get; set; }

    [JsonPropertyName("smbEncryption")]
    public bool? SmbEncryption { get; set; }

    [JsonPropertyName("snapshotDirectoryVisible")]
    public bool? SnapshotDirectoryVisible { get; set; }

    [JsonPropertyName("snapshotId")]
    public string? SnapshotId { get; set; }

    [JsonPropertyName("storageToNetworkProximity")]
    public VolumeStorageToNetworkProximityConstant? StorageToNetworkProximity { get; set; }

    [JsonPropertyName("subnetId")]
    [Required]
    public string SubnetId { get; set; }

    [JsonPropertyName("t2Network")]
    public string? T2Network { get; set; }

    [JsonPropertyName("throughputMibps")]
    public float? ThroughputMibps { get; set; }

    [JsonPropertyName("unixPermissions")]
    public string? UnixPermissions { get; set; }

    [JsonPropertyName("usageThreshold")]
    [Required]
    public int UsageThreshold { get; set; }

    [JsonPropertyName("volumeGroupName")]
    public string? VolumeGroupName { get; set; }

    [JsonPropertyName("volumeSpecName")]
    public string? VolumeSpecName { get; set; }

    [JsonPropertyName("volumeType")]
    public string? VolumeType { get; set; }
}
