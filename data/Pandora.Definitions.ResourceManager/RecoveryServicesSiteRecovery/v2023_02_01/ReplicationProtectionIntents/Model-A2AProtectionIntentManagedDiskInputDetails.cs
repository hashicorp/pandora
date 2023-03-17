using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_02_01.ReplicationProtectionIntents;


internal class A2AProtectionIntentManagedDiskInputDetailsModel
{
    [JsonPropertyName("diskEncryptionInfo")]
    public DiskEncryptionInfoModel? DiskEncryptionInfo { get; set; }

    [JsonPropertyName("diskId")]
    [Required]
    public string DiskId { get; set; }

    [JsonPropertyName("primaryStagingStorageAccountCustomInput")]
    public StorageAccountCustomDetailsModel? PrimaryStagingStorageAccountCustomInput { get; set; }

    [JsonPropertyName("recoveryDiskEncryptionSetId")]
    public string? RecoveryDiskEncryptionSetId { get; set; }

    [JsonPropertyName("recoveryReplicaDiskAccountType")]
    public string? RecoveryReplicaDiskAccountType { get; set; }

    [JsonPropertyName("recoveryResourceGroupCustomInput")]
    public RecoveryResourceGroupCustomDetailsModel? RecoveryResourceGroupCustomInput { get; set; }

    [JsonPropertyName("recoveryTargetDiskAccountType")]
    public string? RecoveryTargetDiskAccountType { get; set; }
}
