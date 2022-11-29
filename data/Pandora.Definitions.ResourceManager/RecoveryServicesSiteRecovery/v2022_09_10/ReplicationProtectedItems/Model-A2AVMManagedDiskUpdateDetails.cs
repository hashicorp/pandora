using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationProtectedItems;


internal class A2AVMManagedDiskUpdateDetailsModel
{
    [JsonPropertyName("diskEncryptionInfo")]
    public DiskEncryptionInfoModel? DiskEncryptionInfo { get; set; }

    [JsonPropertyName("diskId")]
    public string? DiskId { get; set; }

    [JsonPropertyName("failoverDiskName")]
    public string? FailoverDiskName { get; set; }

    [JsonPropertyName("recoveryReplicaDiskAccountType")]
    public string? RecoveryReplicaDiskAccountType { get; set; }

    [JsonPropertyName("recoveryTargetDiskAccountType")]
    public string? RecoveryTargetDiskAccountType { get; set; }

    [JsonPropertyName("tfoDiskName")]
    public string? TfoDiskName { get; set; }
}
