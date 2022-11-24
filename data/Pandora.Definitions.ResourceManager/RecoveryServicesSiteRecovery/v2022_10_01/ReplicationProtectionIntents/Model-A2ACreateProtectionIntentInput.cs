using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectionIntents;

[ValueForType("A2A")]
internal class A2ACreateProtectionIntentInputModel : CreateProtectionIntentProviderSpecificDetailsModel
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
    [Required]
    public string FabricObjectId { get; set; }

    [JsonPropertyName("multiVmGroupId")]
    public string? MultiVmGroupId { get; set; }

    [JsonPropertyName("multiVmGroupName")]
    public string? MultiVmGroupName { get; set; }

    [JsonPropertyName("primaryLocation")]
    [Required]
    public string PrimaryLocation { get; set; }

    [JsonPropertyName("primaryStagingStorageAccountCustomInput")]
    public StorageAccountCustomDetailsModel? PrimaryStagingStorageAccountCustomInput { get; set; }

    [JsonPropertyName("protectionProfileCustomInput")]
    public ProtectionProfileCustomDetailsModel? ProtectionProfileCustomInput { get; set; }

    [JsonPropertyName("recoveryAvailabilitySetCustomInput")]
    public RecoveryAvailabilitySetCustomDetailsModel? RecoveryAvailabilitySetCustomInput { get; set; }

    [JsonPropertyName("recoveryAvailabilityType")]
    [Required]
    public A2ARecoveryAvailabilityTypeConstant RecoveryAvailabilityType { get; set; }

    [JsonPropertyName("recoveryAvailabilityZone")]
    public string? RecoveryAvailabilityZone { get; set; }

    [JsonPropertyName("recoveryBootDiagStorageAccount")]
    public StorageAccountCustomDetailsModel? RecoveryBootDiagStorageAccount { get; set; }

    [JsonPropertyName("recoveryLocation")]
    [Required]
    public string RecoveryLocation { get; set; }

    [JsonPropertyName("recoveryProximityPlacementGroupCustomInput")]
    public RecoveryProximityPlacementGroupCustomDetailsModel? RecoveryProximityPlacementGroupCustomInput { get; set; }

    [JsonPropertyName("recoveryResourceGroupId")]
    [Required]
    public string RecoveryResourceGroupId { get; set; }

    [JsonPropertyName("recoverySubscriptionId")]
    [Required]
    public string RecoverySubscriptionId { get; set; }

    [JsonPropertyName("recoveryVirtualNetworkCustomInput")]
    public RecoveryVirtualNetworkCustomDetailsModel? RecoveryVirtualNetworkCustomInput { get; set; }

    [JsonPropertyName("vmDisks")]
    public List<A2AProtectionIntentDiskInputDetailsModel>? VmDisks { get; set; }

    [JsonPropertyName("vmManagedDisks")]
    public List<A2AProtectionIntentManagedDiskInputDetailsModel>? VmManagedDisks { get; set; }
}
