using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationProtectedItems;

[ValueForType("A2A")]
internal class A2AReplicationDetailsModel : ReplicationProviderSpecificSettingsModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("agentCertificateExpiryDate")]
    public DateTime? AgentCertificateExpiryDate { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("agentExpiryDate")]
    public DateTime? AgentExpiryDate { get; set; }

    [JsonPropertyName("agentVersion")]
    public string? AgentVersion { get; set; }

    [JsonPropertyName("autoProtectionOfDataDisk")]
    public AutoProtectionOfDataDiskConstant? AutoProtectionOfDataDisk { get; set; }

    [JsonPropertyName("fabricObjectId")]
    public string? FabricObjectId { get; set; }

    [JsonPropertyName("initialPrimaryExtendedLocation")]
    public CustomTypes.EdgeZone? InitialPrimaryExtendedLocation { get; set; }

    [JsonPropertyName("initialPrimaryFabricLocation")]
    public string? InitialPrimaryFabricLocation { get; set; }

    [JsonPropertyName("initialPrimaryZone")]
    public string? InitialPrimaryZone { get; set; }

    [JsonPropertyName("initialRecoveryExtendedLocation")]
    public CustomTypes.EdgeZone? InitialRecoveryExtendedLocation { get; set; }

    [JsonPropertyName("initialRecoveryFabricLocation")]
    public string? InitialRecoveryFabricLocation { get; set; }

    [JsonPropertyName("initialRecoveryZone")]
    public string? InitialRecoveryZone { get; set; }

    [JsonPropertyName("isReplicationAgentCertificateUpdateRequired")]
    public bool? IsReplicationAgentCertificateUpdateRequired { get; set; }

    [JsonPropertyName("isReplicationAgentUpdateRequired")]
    public bool? IsReplicationAgentUpdateRequired { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastHeartbeat")]
    public DateTime? LastHeartbeat { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastRpoCalculatedTime")]
    public DateTime? LastRpoCalculatedTime { get; set; }

    [JsonPropertyName("lifecycleId")]
    public string? LifecycleId { get; set; }

    [JsonPropertyName("managementId")]
    public string? ManagementId { get; set; }

    [JsonPropertyName("monitoringJobType")]
    public string? MonitoringJobType { get; set; }

    [JsonPropertyName("monitoringPercentageCompletion")]
    public int? MonitoringPercentageCompletion { get; set; }

    [JsonPropertyName("multiVmGroupCreateOption")]
    public MultiVMGroupCreateOptionConstant? MultiVMGroupCreateOption { get; set; }

    [JsonPropertyName("multiVmGroupId")]
    public string? MultiVMGroupId { get; set; }

    [JsonPropertyName("multiVmGroupName")]
    public string? MultiVMGroupName { get; set; }

    [JsonPropertyName("osType")]
    public string? OsType { get; set; }

    [JsonPropertyName("primaryAvailabilityZone")]
    public string? PrimaryAvailabilityZone { get; set; }

    [JsonPropertyName("primaryExtendedLocation")]
    public CustomTypes.EdgeZone? PrimaryExtendedLocation { get; set; }

    [JsonPropertyName("primaryFabricLocation")]
    public string? PrimaryFabricLocation { get; set; }

    [JsonPropertyName("protectedDisks")]
    public List<A2AProtectedDiskDetailsModel>? ProtectedDisks { get; set; }

    [JsonPropertyName("protectedManagedDisks")]
    public List<A2AProtectedManagedDiskDetailsModel>? ProtectedManagedDisks { get; set; }

    [JsonPropertyName("recoveryAvailabilitySet")]
    public string? RecoveryAvailabilitySet { get; set; }

    [JsonPropertyName("recoveryAvailabilityZone")]
    public string? RecoveryAvailabilityZone { get; set; }

    [JsonPropertyName("recoveryAzureGeneration")]
    public string? RecoveryAzureGeneration { get; set; }

    [JsonPropertyName("recoveryAzureResourceGroupId")]
    public string? RecoveryAzureResourceGroupId { get; set; }

    [JsonPropertyName("recoveryAzureVMName")]
    public string? RecoveryAzureVMName { get; set; }

    [JsonPropertyName("recoveryAzureVMSize")]
    public string? RecoveryAzureVMSize { get; set; }

    [JsonPropertyName("recoveryBootDiagStorageAccountId")]
    public string? RecoveryBootDiagStorageAccountId { get; set; }

    [JsonPropertyName("recoveryCapacityReservationGroupId")]
    public string? RecoveryCapacityReservationGroupId { get; set; }

    [JsonPropertyName("recoveryCloudService")]
    public string? RecoveryCloudService { get; set; }

    [JsonPropertyName("recoveryExtendedLocation")]
    public CustomTypes.EdgeZone? RecoveryExtendedLocation { get; set; }

    [JsonPropertyName("recoveryFabricLocation")]
    public string? RecoveryFabricLocation { get; set; }

    [JsonPropertyName("recoveryFabricObjectId")]
    public string? RecoveryFabricObjectId { get; set; }

    [JsonPropertyName("recoveryProximityPlacementGroupId")]
    public string? RecoveryProximityPlacementGroupId { get; set; }

    [JsonPropertyName("recoveryVirtualMachineScaleSetId")]
    public string? RecoveryVirtualMachineScaleSetId { get; set; }

    [JsonPropertyName("rpoInSeconds")]
    public int? RpoInSeconds { get; set; }

    [JsonPropertyName("selectedRecoveryAzureNetworkId")]
    public string? SelectedRecoveryAzureNetworkId { get; set; }

    [JsonPropertyName("selectedTfoAzureNetworkId")]
    public string? SelectedTfoAzureNetworkId { get; set; }

    [JsonPropertyName("testFailoverRecoveryFabricObjectId")]
    public string? TestFailoverRecoveryFabricObjectId { get; set; }

    [JsonPropertyName("tfoAzureVMName")]
    public string? TfoAzureVMName { get; set; }

    [JsonPropertyName("unprotectedDisks")]
    public List<A2AUnprotectedDiskDetailsModel>? UnprotectedDisks { get; set; }

    [JsonPropertyName("vmEncryptionType")]
    public VMEncryptionTypeConstant? VMEncryptionType { get; set; }

    [JsonPropertyName("vmNics")]
    public List<VMNicDetailsModel>? VMNics { get; set; }

    [JsonPropertyName("vmProtectionState")]
    public string? VMProtectionState { get; set; }

    [JsonPropertyName("vmProtectionStateDescription")]
    public string? VMProtectionStateDescription { get; set; }

    [JsonPropertyName("vmSyncedConfigDetails")]
    public AzureToAzureVMSyncedConfigDetailsModel? VMSyncedConfigDetails { get; set; }
}
