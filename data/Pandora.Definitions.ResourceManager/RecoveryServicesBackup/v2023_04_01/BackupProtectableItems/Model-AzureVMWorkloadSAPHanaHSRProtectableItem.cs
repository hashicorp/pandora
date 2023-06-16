using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_04_01.BackupProtectableItems;

[ValueForType("HanaHSRContainer")]
internal class AzureVMWorkloadSAPHanaHSRProtectableItemModel : WorkloadProtectableItemModel
{
    [JsonPropertyName("isAutoProtectable")]
    public bool? IsAutoProtectable { get; set; }

    [JsonPropertyName("isAutoProtected")]
    public bool? IsAutoProtected { get; set; }

    [JsonPropertyName("isProtectable")]
    public bool? IsProtectable { get; set; }

    [JsonPropertyName("parentName")]
    public string? ParentName { get; set; }

    [JsonPropertyName("parentUniqueName")]
    public string? ParentUniqueName { get; set; }

    [JsonPropertyName("prebackupvalidation")]
    public PreBackupValidationModel? Prebackupvalidation { get; set; }

    [JsonPropertyName("serverName")]
    public string? ServerName { get; set; }

    [JsonPropertyName("subinquireditemcount")]
    public int? Subinquireditemcount { get; set; }

    [JsonPropertyName("subprotectableitemcount")]
    public int? Subprotectableitemcount { get; set; }
}
