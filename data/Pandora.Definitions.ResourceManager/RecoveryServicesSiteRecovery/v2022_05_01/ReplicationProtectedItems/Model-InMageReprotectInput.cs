using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationProtectedItems;

[ValueForType("InMage")]
internal class InMageReprotectInputModel : ReverseReplicationProviderSpecificInputModel
{
    [JsonPropertyName("datastoreName")]
    public string? DatastoreName { get; set; }

    [JsonPropertyName("diskExclusionInput")]
    public InMageDiskExclusionInputModel? DiskExclusionInput { get; set; }

    [JsonPropertyName("disksToInclude")]
    public List<string>? DisksToInclude { get; set; }

    [JsonPropertyName("masterTargetId")]
    [Required]
    public string MasterTargetId { get; set; }

    [JsonPropertyName("processServerId")]
    [Required]
    public string ProcessServerId { get; set; }

    [JsonPropertyName("profileId")]
    [Required]
    public string ProfileId { get; set; }

    [JsonPropertyName("retentionDrive")]
    [Required]
    public string RetentionDrive { get; set; }

    [JsonPropertyName("runAsAccountId")]
    public string? RunAsAccountId { get; set; }
}
