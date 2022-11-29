using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectedItems;

[ValueForType("InMageAzureV2")]
internal class InMageAzureV2ReplicationDetailsModel : ReplicationProviderSpecificSettingsModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("agentExpiryDate")]
    public DateTime? AgentExpiryDate { get; set; }

    [JsonPropertyName("agentVersion")]
    public string? AgentVersion { get; set; }

    [JsonPropertyName("azureVMDiskDetails")]
    public List<AzureVMDiskDetailsModel>? AzureVMDiskDetails { get; set; }

    [JsonPropertyName("azureVmGeneration")]
    public string? AzureVMGeneration { get; set; }

    [JsonPropertyName("compressedDataRateInMB")]
    public float? CompressedDataRateInMB { get; set; }

    [JsonPropertyName("datastores")]
    public List<string>? DataStores { get; set; }

    [JsonPropertyName("discoveryType")]
    public string? DiscoveryType { get; set; }

    [JsonPropertyName("diskResized")]
    public string? DiskResized { get; set; }

    [JsonPropertyName("enableRdpOnTargetOption")]
    public string? EnableRdpOnTargetOption { get; set; }

    [JsonPropertyName("firmwareType")]
    public string? FirmwareType { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IPAddress { get; set; }

    [JsonPropertyName("infrastructureVmId")]
    public string? InfrastructureVMId { get; set; }

    [JsonPropertyName("isAdditionalStatsAvailable")]
    public bool? IsAdditionalStatsAvailable { get; set; }

    [JsonPropertyName("isAgentUpdateRequired")]
    public string? IsAgentUpdateRequired { get; set; }

    [JsonPropertyName("isRebootAfterUpdateRequired")]
    public string? IsRebootAfterUpdateRequired { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastHeartbeat")]
    public DateTime? LastHeartbeat { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastRecoveryPointReceived")]
    public DateTime? LastRecoveryPointReceived { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastRpoCalculatedTime")]
    public DateTime? LastRpoCalculatedTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUpdateReceivedTime")]
    public DateTime? LastUpdateReceivedTime { get; set; }

    [JsonPropertyName("licenseType")]
    public string? LicenseType { get; set; }

    [JsonPropertyName("masterTargetId")]
    public string? MasterTargetId { get; set; }

    [JsonPropertyName("multiVmGroupId")]
    public string? MultiVMGroupId { get; set; }

    [JsonPropertyName("multiVmGroupName")]
    public string? MultiVMGroupName { get; set; }

    [JsonPropertyName("multiVmSyncStatus")]
    public string? MultiVMSyncStatus { get; set; }

    [JsonPropertyName("osDiskId")]
    public string? OsDiskId { get; set; }

    [JsonPropertyName("osType")]
    public string? OsType { get; set; }

    [JsonPropertyName("osVersion")]
    public string? OsVersion { get; set; }

    [JsonPropertyName("processServerId")]
    public string? ProcessServerId { get; set; }

    [JsonPropertyName("processServerName")]
    public string? ProcessServerName { get; set; }

    [JsonPropertyName("protectedDisks")]
    public List<InMageAzureV2ProtectedDiskDetailsModel>? ProtectedDisks { get; set; }

    [JsonPropertyName("protectedManagedDisks")]
    public List<InMageAzureV2ManagedDiskDetailsModel>? ProtectedManagedDisks { get; set; }

    [JsonPropertyName("protectionStage")]
    public string? ProtectionStage { get; set; }

    [JsonPropertyName("recoveryAvailabilitySetId")]
    public string? RecoveryAvailabilitySetId { get; set; }

    [JsonPropertyName("recoveryAzureLogStorageAccountId")]
    public string? RecoveryAzureLogStorageAccountId { get; set; }

    [JsonPropertyName("recoveryAzureResourceGroupId")]
    public string? RecoveryAzureResourceGroupId { get; set; }

    [JsonPropertyName("recoveryAzureStorageAccount")]
    public string? RecoveryAzureStorageAccount { get; set; }

    [JsonPropertyName("recoveryAzureVMName")]
    public string? RecoveryAzureVMName { get; set; }

    [JsonPropertyName("recoveryAzureVMSize")]
    public string? RecoveryAzureVMSize { get; set; }

    [JsonPropertyName("replicaId")]
    public string? ReplicaId { get; set; }

    [JsonPropertyName("resyncProgressPercentage")]
    public int? ResyncProgressPercentage { get; set; }

    [JsonPropertyName("rpoInSeconds")]
    public int? RpoInSeconds { get; set; }

    [JsonPropertyName("seedManagedDiskTags")]
    public Dictionary<string, string>? SeedManagedDiskTags { get; set; }

    [JsonPropertyName("selectedRecoveryAzureNetworkId")]
    public string? SelectedRecoveryAzureNetworkId { get; set; }

    [JsonPropertyName("selectedSourceNicId")]
    public string? SelectedSourceNicId { get; set; }

    [JsonPropertyName("selectedTfoAzureNetworkId")]
    public string? SelectedTfoAzureNetworkId { get; set; }

    [JsonPropertyName("sourceVmCpuCount")]
    public int? SourceVMCPUCount { get; set; }

    [JsonPropertyName("sourceVmRamSizeInMB")]
    public int? SourceVMRamSizeInMB { get; set; }

    [JsonPropertyName("sqlServerLicenseType")]
    public string? SqlServerLicenseType { get; set; }

    [JsonPropertyName("switchProviderBlockingErrorDetails")]
    public List<InMageAzureV2SwitchProviderBlockingErrorDetailsModel>? SwitchProviderBlockingErrorDetails { get; set; }

    [JsonPropertyName("switchProviderDetails")]
    public InMageAzureV2SwitchProviderDetailsModel? SwitchProviderDetails { get; set; }

    [JsonPropertyName("targetAvailabilityZone")]
    public string? TargetAvailabilityZone { get; set; }

    [JsonPropertyName("targetManagedDiskTags")]
    public Dictionary<string, string>? TargetManagedDiskTags { get; set; }

    [JsonPropertyName("targetNicTags")]
    public Dictionary<string, string>? TargetNicTags { get; set; }

    [JsonPropertyName("targetProximityPlacementGroupId")]
    public string? TargetProximityPlacementGroupId { get; set; }

    [JsonPropertyName("targetVmId")]
    public string? TargetVMId { get; set; }

    [JsonPropertyName("targetVmTags")]
    public Dictionary<string, string>? TargetVMTags { get; set; }

    [JsonPropertyName("totalDataTransferred")]
    public int? TotalDataTransferred { get; set; }

    [JsonPropertyName("totalProgressHealth")]
    public string? TotalProgressHealth { get; set; }

    [JsonPropertyName("uncompressedDataRateInMB")]
    public float? UncompressedDataRateInMB { get; set; }

    [JsonPropertyName("useManagedDisks")]
    public string? UseManagedDisks { get; set; }

    [JsonPropertyName("vCenterInfrastructureId")]
    public string? VCenterInfrastructureId { get; set; }

    [JsonPropertyName("vmId")]
    public string? VMId { get; set; }

    [JsonPropertyName("vmNics")]
    public List<VMNicDetailsModel>? VMNics { get; set; }

    [JsonPropertyName("vmProtectionState")]
    public string? VMProtectionState { get; set; }

    [JsonPropertyName("vmProtectionStateDescription")]
    public string? VMProtectionStateDescription { get; set; }

    [JsonPropertyName("validationErrors")]
    public List<HealthErrorModel>? ValidationErrors { get; set; }

    [JsonPropertyName("vhdName")]
    public string? VhdName { get; set; }
}
