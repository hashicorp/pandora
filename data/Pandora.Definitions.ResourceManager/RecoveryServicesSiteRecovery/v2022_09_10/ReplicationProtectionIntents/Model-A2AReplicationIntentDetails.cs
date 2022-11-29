using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationProtectionIntents;

[ValueForType("A2A")]
internal class A2AReplicationIntentDetailsModel : ReplicationProtectionIntentProviderSpecificSettingsModel
{
    [JsonPropertyName("agentAutoUpdateStatus")]
    public AgentAutoUpdateStatusConstant? AgentAutoUpdateStatus { get; set; }

    [JsonPropertyName("autoProtectionOfDataDisk")]
    public AutoProtectionOfDataDiskConstant? AutoProtectionOfDataDisk { get; set; }

    [JsonPropertyName("automationAccountArmId")]
    public string? AutomationAccountArmId { get; set; }

    [JsonPropertyName("automationAccountAuthenticationType")]
    public AutomationAccountAuthenticationTypeConstant? AutomationAccountAuthenticationType { get; set; }

    [JsonPropertyName("diskEncryptionInfo")]
    public DiskEncryptionInfoModel? DiskEncryptionInfo { get; set; }

    [JsonPropertyName("fabricObjectId")]
    public string? FabricObjectId { get; set; }

    [JsonPropertyName("multiVmGroupId")]
    public string? MultiVMGroupId { get; set; }

    [JsonPropertyName("multiVmGroupName")]
    public string? MultiVMGroupName { get; set; }

    [JsonPropertyName("primaryLocation")]
    public string? PrimaryLocation { get; set; }

    [JsonPropertyName("primaryStagingStorageAccount")]
    public StorageAccountCustomDetailsModel? PrimaryStagingStorageAccount { get; set; }

    [JsonPropertyName("protectionProfile")]
    public ProtectionProfileCustomDetailsModel? ProtectionProfile { get; set; }

    [JsonPropertyName("recoveryAvailabilitySet")]
    public RecoveryAvailabilitySetCustomDetailsModel? RecoveryAvailabilitySet { get; set; }

    [JsonPropertyName("recoveryAvailabilityType")]
    [Required]
    public string RecoveryAvailabilityType { get; set; }

    [JsonPropertyName("recoveryAvailabilityZone")]
    public string? RecoveryAvailabilityZone { get; set; }

    [JsonPropertyName("recoveryBootDiagStorageAccount")]
    public StorageAccountCustomDetailsModel? RecoveryBootDiagStorageAccount { get; set; }

    [JsonPropertyName("recoveryLocation")]
    public string? RecoveryLocation { get; set; }

    [JsonPropertyName("recoveryProximityPlacementGroup")]
    public RecoveryProximityPlacementGroupCustomDetailsModel? RecoveryProximityPlacementGroup { get; set; }

    [JsonPropertyName("recoveryResourceGroupId")]
    public string? RecoveryResourceGroupId { get; set; }

    [JsonPropertyName("recoverySubscriptionId")]
    public string? RecoverySubscriptionId { get; set; }

    [JsonPropertyName("recoveryVirtualNetwork")]
    public RecoveryVirtualNetworkCustomDetailsModel? RecoveryVirtualNetwork { get; set; }

    [JsonPropertyName("vmDisks")]
    public List<A2AProtectionIntentDiskInputDetailsModel>? VMDisks { get; set; }

    [JsonPropertyName("vmManagedDisks")]
    public List<A2AProtectionIntentManagedDiskInputDetailsModel>? VMManagedDisks { get; set; }
}
