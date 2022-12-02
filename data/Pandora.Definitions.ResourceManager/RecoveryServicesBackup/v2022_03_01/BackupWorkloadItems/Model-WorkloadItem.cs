using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.BackupWorkloadItems;


internal abstract class WorkloadItemModel
{
    [JsonPropertyName("backupManagementType")]
    public string? BackupManagementType { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("protectionState")]
    public ProtectionStatusConstant? ProtectionState { get; set; }

    [JsonPropertyName("workloadItemType")]
    [ProvidesTypeHint]
    [Required]
    public string WorkloadItemType { get; set; }

    [JsonPropertyName("workloadType")]
    public string? WorkloadType { get; set; }
}
