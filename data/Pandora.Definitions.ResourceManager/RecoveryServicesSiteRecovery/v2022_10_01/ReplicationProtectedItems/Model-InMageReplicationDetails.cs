using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectedItems;

[ValueForType("InMage")]
internal class InMageReplicationDetailsModel : ReplicationProviderSpecificSettingsModel
{
    [JsonPropertyName("activeSiteType")]
    public string? ActiveSiteType { get; set; }

    [JsonPropertyName("agentDetails")]
    public InMageAgentDetailsModel? AgentDetails { get; set; }

    [JsonPropertyName("azureStorageAccountId")]
    public string? AzureStorageAccountId { get; set; }

    [JsonPropertyName("compressedDataRateInMB")]
    public float? CompressedDataRateInMB { get; set; }

    [JsonPropertyName("consistencyPoints")]
    public Dictionary<string, DateTime>? ConsistencyPoints { get; set; }

    [JsonPropertyName("datastores")]
    public List<string>? DataStores { get; set; }

    [JsonPropertyName("discoveryType")]
    public string? DiscoveryType { get; set; }

    [JsonPropertyName("diskResized")]
    public string? DiskResized { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IPAddress { get; set; }

    [JsonPropertyName("infrastructureVmId")]
    public string? InfrastructureVMId { get; set; }

    [JsonPropertyName("isAdditionalStatsAvailable")]
    public bool? IsAdditionalStatsAvailable { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastHeartbeat")]
    public DateTime? LastHeartbeat { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastRpoCalculatedTime")]
    public DateTime? LastRpoCalculatedTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUpdateReceivedTime")]
    public DateTime? LastUpdateReceivedTime { get; set; }

    [JsonPropertyName("masterTargetId")]
    public string? MasterTargetId { get; set; }

    [JsonPropertyName("multiVmGroupId")]
    public string? MultiVMGroupId { get; set; }

    [JsonPropertyName("multiVmGroupName")]
    public string? MultiVMGroupName { get; set; }

    [JsonPropertyName("multiVmSyncStatus")]
    public string? MultiVMSyncStatus { get; set; }

    [JsonPropertyName("osDetails")]
    public OSDiskDetailsModel? OsDetails { get; set; }

    [JsonPropertyName("osVersion")]
    public string? OsVersion { get; set; }

    [JsonPropertyName("processServerId")]
    public string? ProcessServerId { get; set; }

    [JsonPropertyName("protectedDisks")]
    public List<InMageProtectedDiskDetailsModel>? ProtectedDisks { get; set; }

    [JsonPropertyName("protectionStage")]
    public string? ProtectionStage { get; set; }

    [JsonPropertyName("rebootAfterUpdateStatus")]
    public string? RebootAfterUpdateStatus { get; set; }

    [JsonPropertyName("replicaId")]
    public string? ReplicaId { get; set; }

    [JsonPropertyName("resyncDetails")]
    public InitialReplicationDetailsModel? ResyncDetails { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("retentionWindowEnd")]
    public DateTime? RetentionWindowEnd { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("retentionWindowStart")]
    public DateTime? RetentionWindowStart { get; set; }

    [JsonPropertyName("rpoInSeconds")]
    public int? RpoInSeconds { get; set; }

    [JsonPropertyName("sourceVmCpuCount")]
    public int? SourceVMCPUCount { get; set; }

    [JsonPropertyName("sourceVmRamSizeInMB")]
    public int? SourceVMRamSizeInMB { get; set; }

    [JsonPropertyName("totalDataTransferred")]
    public int? TotalDataTransferred { get; set; }

    [JsonPropertyName("totalProgressHealth")]
    public string? TotalProgressHealth { get; set; }

    [JsonPropertyName("uncompressedDataRateInMB")]
    public float? UncompressedDataRateInMB { get; set; }

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
}
