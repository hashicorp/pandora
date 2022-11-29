using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationProtectedItems;


internal class AzureVMDiskDetailsModel
{
    [JsonPropertyName("customTargetDiskName")]
    public string? CustomTargetDiskName { get; set; }

    [JsonPropertyName("diskEncryptionSetId")]
    public string? DiskEncryptionSetId { get; set; }

    [JsonPropertyName("diskId")]
    public string? DiskId { get; set; }

    [JsonPropertyName("lunId")]
    public string? LunId { get; set; }

    [JsonPropertyName("maxSizeMB")]
    public string? MaxSizeMB { get; set; }

    [JsonPropertyName("targetDiskLocation")]
    public string? TargetDiskLocation { get; set; }

    [JsonPropertyName("targetDiskName")]
    public string? TargetDiskName { get; set; }

    [JsonPropertyName("vhdId")]
    public string? VhdId { get; set; }

    [JsonPropertyName("vhdName")]
    public string? VhdName { get; set; }

    [JsonPropertyName("vhdType")]
    public string? VhdType { get; set; }
}
