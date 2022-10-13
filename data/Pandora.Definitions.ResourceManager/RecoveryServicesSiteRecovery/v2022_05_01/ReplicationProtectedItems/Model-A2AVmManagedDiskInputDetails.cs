using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationProtectedItems;


internal class A2AVmManagedDiskInputDetailsModel
{
    [JsonPropertyName("diskEncryptionInfo")]
    public DiskEncryptionInfoModel? DiskEncryptionInfo { get; set; }

    [JsonPropertyName("diskId")]
    [Required]
    public string DiskId { get; set; }

    [JsonPropertyName("primaryStagingAzureStorageAccountId")]
    [Required]
    public string PrimaryStagingAzureStorageAccountId { get; set; }

    [JsonPropertyName("recoveryDiskEncryptionSetId")]
    public string? RecoveryDiskEncryptionSetId { get; set; }

    [JsonPropertyName("recoveryReplicaDiskAccountType")]
    public string? RecoveryReplicaDiskAccountType { get; set; }

    [JsonPropertyName("recoveryResourceGroupId")]
    [Required]
    public string RecoveryResourceGroupId { get; set; }

    [JsonPropertyName("recoveryTargetDiskAccountType")]
    public string? RecoveryTargetDiskAccountType { get; set; }
}
