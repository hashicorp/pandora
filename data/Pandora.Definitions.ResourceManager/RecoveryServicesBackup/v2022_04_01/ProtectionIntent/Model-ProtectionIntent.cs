using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_04_01.ProtectionIntent;


internal abstract class ProtectionIntentModel
{
    [JsonPropertyName("backupManagementType")]
    public BackupManagementTypeConstant? BackupManagementType { get; set; }

    [JsonPropertyName("itemId")]
    public string? ItemId { get; set; }

    [JsonPropertyName("policyId")]
    public string? PolicyId { get; set; }

    [JsonPropertyName("protectionIntentItemType")]
    [ProvidesTypeHint]
    [Required]
    public ProtectionIntentItemTypeConstant ProtectionIntentItemType { get; set; }

    [JsonPropertyName("protectionState")]
    public ProtectionStatusConstant? ProtectionState { get; set; }

    [JsonPropertyName("sourceResourceId")]
    public string? SourceResourceId { get; set; }
}
