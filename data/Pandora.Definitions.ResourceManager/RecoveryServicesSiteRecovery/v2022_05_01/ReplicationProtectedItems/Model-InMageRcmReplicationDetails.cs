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
internal class InMageRcmReplicationDetailsModel : ReplicationProviderSpecificSettingsModel
{
    [JsonPropertyName("agentUpgradeAttemptToVersion")]
    public string? AgentUpgradeAttemptToVersion { get; set; }

    [JsonPropertyName("agentUpgradeBlockingErrorDetails")]
    public List<InMageRcmAgentUpgradeBlockingErrorDetailsModel>? AgentUpgradeBlockingErrorDetails { get; set; }

    [JsonPropertyName("agentUpgradeJobId")]
    public string? AgentUpgradeJobId { get; set; }

    [JsonPropertyName("agentUpgradeState")]
    public MobilityAgentUpgradeStateConstant? AgentUpgradeState { get; set; }

    [JsonPropertyName("allocatedMemoryInMB")]
    public float? AllocatedMemoryInMB { get; set; }

    [JsonPropertyName("discoveredVmDetails")]
    public InMageRcmDiscoveredProtectedVMDetailsModel? DiscoveredVMDetails { get; set; }

    [JsonPropertyName("discoveryType")]
    public string? DiscoveryType { get; set; }

    [JsonPropertyName("fabricDiscoveryMachineId")]
    public string? FabricDiscoveryMachineId { get; set; }

    [JsonPropertyName("failoverRecoveryPointId")]
    public string? FailoverRecoveryPointId { get; set; }

    [JsonPropertyName("firmwareType")]
    public string? FirmwareType { get; set; }

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

    [JsonPropertyName("isLastUpgradeSuccessful")]
    public string? IsLastUpgradeSuccessful { get; set; }

    [JsonPropertyName("lastAgentUpgradeErrorDetails")]
    public List<InMageRcmLastAgentUpgradeErrorDetailsModel>? LastAgentUpgradeErrorDetails { get; set; }

    [JsonPropertyName("lastAgentUpgradeType")]
    public string? LastAgentUpgradeType { get; set; }

    [JsonPropertyName("lastRecoveryPointId")]
    public string? LastRecoveryPointId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastRecoveryPointReceived")]
    public DateTime? LastRecoveryPointReceived { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastRpoCalculatedTime")]
    public DateTime? LastRpoCalculatedTime { get; set; }

    [JsonPropertyName("lastRpoInSeconds")]
    public int? LastRpoInSeconds { get; set; }

    [JsonPropertyName("licenseType")]
    public string? LicenseType { get; set; }

    [JsonPropertyName("mobilityAgentDetails")]
    public InMageRcmMobilityAgentDetailsModel? MobilityAgentDetails { get; set; }

    [JsonPropertyName("multiVmGroupName")]
    public string? MultiVMGroupName { get; set; }

    [JsonPropertyName("osType")]
    public string? OsType { get; set; }

    [JsonPropertyName("primaryNicIpAddress")]
    public string? PrimaryNicIPAddress { get; set; }

    [JsonPropertyName("processServerId")]
    public string? ProcessServerId { get; set; }

    [JsonPropertyName("processServerName")]
    public string? ProcessServerName { get; set; }

    [JsonPropertyName("processorCoreCount")]
    public int? ProcessorCoreCount { get; set; }

    [JsonPropertyName("protectedDisks")]
    public List<InMageRcmProtectedDiskDetailsModel>? ProtectedDisks { get; set; }

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

    [JsonPropertyName("runAsAccountId")]
    public string? RunAsAccountId { get; set; }

    [JsonPropertyName("storageAccountId")]
    public string? StorageAccountId { get; set; }

    [JsonPropertyName("targetAvailabilitySetId")]
    public string? TargetAvailabilitySetId { get; set; }

    [JsonPropertyName("targetAvailabilityZone")]
    public string? TargetAvailabilityZone { get; set; }

    [JsonPropertyName("targetBootDiagnosticsStorageAccountId")]
    public string? TargetBootDiagnosticsStorageAccountId { get; set; }

    [JsonPropertyName("targetGeneration")]
    public string? TargetGeneration { get; set; }

    [JsonPropertyName("targetLocation")]
    public string? TargetLocation { get; set; }

    [JsonPropertyName("targetNetworkId")]
    public string? TargetNetworkId { get; set; }

    [JsonPropertyName("targetProximityPlacementGroupId")]
    public string? TargetProximityPlacementGroupId { get; set; }

    [JsonPropertyName("targetResourceGroupId")]
    public string? TargetResourceGroupId { get; set; }

    [JsonPropertyName("targetVmName")]
    public string? TargetVMName { get; set; }

    [JsonPropertyName("targetVmSize")]
    public string? TargetVMSize { get; set; }

    [JsonPropertyName("testNetworkId")]
    public string? TestNetworkId { get; set; }

    [JsonPropertyName("vmNics")]
    public List<InMageRcmNicDetailsModel>? VMNics { get; set; }
}
