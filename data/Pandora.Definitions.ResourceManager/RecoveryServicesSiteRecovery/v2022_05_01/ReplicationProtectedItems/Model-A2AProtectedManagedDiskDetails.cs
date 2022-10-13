using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationProtectedItems;


internal class A2AProtectedManagedDiskDetailsModel
{
    [JsonPropertyName("allowedDiskLevelOperation")]
    public List<string>? AllowedDiskLevelOperation { get; set; }

    [JsonPropertyName("dataPendingAtSourceAgentInMB")]
    public float? DataPendingAtSourceAgentInMB { get; set; }

    [JsonPropertyName("dataPendingInStagingStorageAccountInMB")]
    public float? DataPendingInStagingStorageAccountInMB { get; set; }

    [JsonPropertyName("dekKeyVaultArmId")]
    public string? DekKeyVaultArmId { get; set; }

    [JsonPropertyName("diskCapacityInBytes")]
    public int? DiskCapacityInBytes { get; set; }

    [JsonPropertyName("diskId")]
    public string? DiskId { get; set; }

    [JsonPropertyName("diskName")]
    public string? DiskName { get; set; }

    [JsonPropertyName("diskState")]
    public string? DiskState { get; set; }

    [JsonPropertyName("diskType")]
    public string? DiskType { get; set; }

    [JsonPropertyName("failoverDiskName")]
    public string? FailoverDiskName { get; set; }

    [JsonPropertyName("isDiskEncrypted")]
    public bool? IsDiskEncrypted { get; set; }

    [JsonPropertyName("isDiskKeyEncrypted")]
    public bool? IsDiskKeyEncrypted { get; set; }

    [JsonPropertyName("kekKeyVaultArmId")]
    public string? KekKeyVaultArmId { get; set; }

    [JsonPropertyName("keyIdentifier")]
    public string? KeyIdentifier { get; set; }

    [JsonPropertyName("monitoringJobType")]
    public string? MonitoringJobType { get; set; }

    [JsonPropertyName("monitoringPercentageCompletion")]
    public int? MonitoringPercentageCompletion { get; set; }

    [JsonPropertyName("primaryDiskEncryptionSetId")]
    public string? PrimaryDiskEncryptionSetId { get; set; }

    [JsonPropertyName("primaryStagingAzureStorageAccountId")]
    public string? PrimaryStagingAzureStorageAccountId { get; set; }

    [JsonPropertyName("recoveryDiskEncryptionSetId")]
    public string? RecoveryDiskEncryptionSetId { get; set; }

    [JsonPropertyName("recoveryOrignalTargetDiskId")]
    public string? RecoveryOrignalTargetDiskId { get; set; }

    [JsonPropertyName("recoveryReplicaDiskAccountType")]
    public string? RecoveryReplicaDiskAccountType { get; set; }

    [JsonPropertyName("recoveryReplicaDiskId")]
    public string? RecoveryReplicaDiskId { get; set; }

    [JsonPropertyName("recoveryResourceGroupId")]
    public string? RecoveryResourceGroupId { get; set; }

    [JsonPropertyName("recoveryTargetDiskAccountType")]
    public string? RecoveryTargetDiskAccountType { get; set; }

    [JsonPropertyName("recoveryTargetDiskId")]
    public string? RecoveryTargetDiskId { get; set; }

    [JsonPropertyName("resyncRequired")]
    public bool? ResyncRequired { get; set; }

    [JsonPropertyName("secretIdentifier")]
    public string? SecretIdentifier { get; set; }

    [JsonPropertyName("tfoDiskName")]
    public string? TfoDiskName { get; set; }
}
