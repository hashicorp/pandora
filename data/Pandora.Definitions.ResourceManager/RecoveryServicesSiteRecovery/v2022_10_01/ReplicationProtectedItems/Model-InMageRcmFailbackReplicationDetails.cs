using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectedItems;

[ValueForType("InMageRcmFailback")]
internal class InMageRcmFailbackReplicationDetailsModel : ReplicationProviderSpecificSettingsModel
{
    [JsonPropertyName("azureVirtualMachineId")]
    public string? AzureVirtualMachineId { get; set; }

    [JsonPropertyName("discoveredVmDetails")]
    public InMageRcmFailbackDiscoveredProtectedVMDetailsModel? DiscoveredVMDetails { get; set; }

    [JsonPropertyName("initialReplicationProcessedBytes")]
    public int? InitialReplicationProcessedBytes { get; set; }

    [JsonPropertyName("initialReplicationProgressHealth")]
    public VMReplicationProgressHealthConstant? InitialReplicationProgressHealth { get; set; }

    [JsonPropertyName("initialReplicationProgressPercentage")]
    public int? InitialReplicationProgressPercentage { get; set; }

    [JsonPropertyName("initialReplicationTransferredBytes")]
    public int? InitialReplicationTransferredBytes { get; set; }

    [JsonPropertyName("internalIdentifier")]
    public string? InternalIdentifier { get; set; }

    [JsonPropertyName("isAgentRegistrationSuccessfulAfterFailover")]
    public bool? IsAgentRegistrationSuccessfulAfterFailover { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastPlannedFailoverStartTime")]
    public DateTime? LastPlannedFailoverStartTime { get; set; }

    [JsonPropertyName("lastPlannedFailoverStatus")]
    public PlannedFailoverStatusConstant? LastPlannedFailoverStatus { get; set; }

    [JsonPropertyName("lastUsedPolicyFriendlyName")]
    public string? LastUsedPolicyFriendlyName { get; set; }

    [JsonPropertyName("lastUsedPolicyId")]
    public string? LastUsedPolicyId { get; set; }

    [JsonPropertyName("logStorageAccountId")]
    public string? LogStorageAccountId { get; set; }

    [JsonPropertyName("mobilityAgentDetails")]
    public InMageRcmFailbackMobilityAgentDetailsModel? MobilityAgentDetails { get; set; }

    [JsonPropertyName("multiVmGroupName")]
    public string? MultiVMGroupName { get; set; }

    [JsonPropertyName("osType")]
    public string? OsType { get; set; }

    [JsonPropertyName("protectedDisks")]
    public List<InMageRcmFailbackProtectedDiskDetailsModel>? ProtectedDisks { get; set; }

    [JsonPropertyName("reprotectAgentId")]
    public string? ReprotectAgentId { get; set; }

    [JsonPropertyName("reprotectAgentName")]
    public string? ReprotectAgentName { get; set; }

    [JsonPropertyName("resyncProcessedBytes")]
    public int? ResyncProcessedBytes { get; set; }

    [JsonPropertyName("resyncProgressHealth")]
    public VMReplicationProgressHealthConstant? ResyncProgressHealth { get; set; }

    [JsonPropertyName("resyncProgressPercentage")]
    public int? ResyncProgressPercentage { get; set; }

    [JsonPropertyName("resyncRequired")]
    public string? ResyncRequired { get; set; }

    [JsonPropertyName("resyncState")]
    public ResyncStateConstant? ResyncState { get; set; }

    [JsonPropertyName("resyncTransferredBytes")]
    public int? ResyncTransferredBytes { get; set; }

    [JsonPropertyName("targetDataStoreName")]
    public string? TargetDataStoreName { get; set; }

    [JsonPropertyName("targetVmName")]
    public string? TargetVMName { get; set; }

    [JsonPropertyName("targetvCenterId")]
    public string? TargetvCenterId { get; set; }

    [JsonPropertyName("vmNics")]
    public List<InMageRcmFailbackNicDetailsModel>? VMNics { get; set; }
}
