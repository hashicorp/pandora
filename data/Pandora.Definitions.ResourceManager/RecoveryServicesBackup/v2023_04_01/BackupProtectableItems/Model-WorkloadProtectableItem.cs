using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_04_01.BackupProtectableItems;


internal abstract class WorkloadProtectableItemModel
{
    [JsonPropertyName("backupManagementType")]
    public string? BackupManagementType { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("protectableItemType")]
    [ProvidesTypeHint]
    [Required]
    public string ProtectableItemType { get; set; }

    [JsonPropertyName("protectionState")]
    public ProtectionStatusConstant? ProtectionState { get; set; }

    [JsonPropertyName("workloadType")]
    public string? WorkloadType { get; set; }
}
