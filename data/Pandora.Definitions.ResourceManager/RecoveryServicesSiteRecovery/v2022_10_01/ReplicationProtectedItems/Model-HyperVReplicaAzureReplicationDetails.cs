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
internal class HyperVReplicaAzureReplicationDetailsModel : ReplicationProviderSpecificSettingsModel
{
    [JsonPropertyName("azureVmDiskDetails")]
    public List<AzureVmDiskDetailsModel>? AzureVmDiskDetails { get; set; }

    [JsonPropertyName("enableRdpOnTargetOption")]
    public string? EnableRdpOnTargetOption { get; set; }

    [JsonPropertyName("encryption")]
    public string? Encryption { get; set; }

    [JsonPropertyName("initialReplicationDetails")]
    public InitialReplicationDetailsModel? InitialReplicationDetails { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastRecoveryPointReceived")]
    public DateTime? LastRecoveryPointReceived { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastReplicatedTime")]
    public DateTime? LastReplicatedTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastRpoCalculatedTime")]
    public DateTime? LastRpoCalculatedTime { get; set; }

    [JsonPropertyName("licenseType")]
    public string? LicenseType { get; set; }

    [JsonPropertyName("oSDetails")]
    public OSDetailsModel? OSDetails { get; set; }

    [JsonPropertyName("protectedManagedDisks")]
    public List<HyperVReplicaAzureManagedDiskDetailsModel>? ProtectedManagedDisks { get; set; }

    [JsonPropertyName("recoveryAvailabilitySetId")]
    public string? RecoveryAvailabilitySetId { get; set; }

    [JsonPropertyName("recoveryAzureLogStorageAccountId")]
    public string? RecoveryAzureLogStorageAccountId { get; set; }

    [JsonPropertyName("recoveryAzureResourceGroupId")]
    public string? RecoveryAzureResourceGroupId { get; set; }

    [JsonPropertyName("recoveryAzureStorageAccount")]
    public string? RecoveryAzureStorageAccount { get; set; }

    [JsonPropertyName("recoveryAzureVMSize")]
    public string? RecoveryAzureVMSize { get; set; }

    [JsonPropertyName("recoveryAzureVmName")]
    public string? RecoveryAzureVmName { get; set; }

    [JsonPropertyName("rpoInSeconds")]
    public int? RpoInSeconds { get; set; }

    [JsonPropertyName("seedManagedDiskTags")]
    public Dictionary<string, string>? SeedManagedDiskTags { get; set; }

    [JsonPropertyName("selectedRecoveryAzureNetworkId")]
    public string? SelectedRecoveryAzureNetworkId { get; set; }

    [JsonPropertyName("selectedSourceNicId")]
    public string? SelectedSourceNicId { get; set; }

    [JsonPropertyName("sourceVmCpuCount")]
    public int? SourceVmCpuCount { get; set; }

    [JsonPropertyName("sourceVmRamSizeInMB")]
    public int? SourceVmRamSizeInMB { get; set; }

    [JsonPropertyName("sqlServerLicenseType")]
    public string? SqlServerLicenseType { get; set; }

    [JsonPropertyName("targetAvailabilityZone")]
    public string? TargetAvailabilityZone { get; set; }

    [JsonPropertyName("targetManagedDiskTags")]
    public Dictionary<string, string>? TargetManagedDiskTags { get; set; }

    [JsonPropertyName("targetNicTags")]
    public Dictionary<string, string>? TargetNicTags { get; set; }

    [JsonPropertyName("targetProximityPlacementGroupId")]
    public string? TargetProximityPlacementGroupId { get; set; }

    [JsonPropertyName("targetVmTags")]
    public Dictionary<string, string>? TargetVmTags { get; set; }

    [JsonPropertyName("useManagedDisks")]
    public string? UseManagedDisks { get; set; }

    [JsonPropertyName("vmId")]
    public string? VmId { get; set; }

    [JsonPropertyName("vmNics")]
    public List<VMNicDetailsModel>? VmNics { get; set; }

    [JsonPropertyName("vmProtectionState")]
    public string? VmProtectionState { get; set; }

    [JsonPropertyName("vmProtectionStateDescription")]
    public string? VmProtectionStateDescription { get; set; }
}
