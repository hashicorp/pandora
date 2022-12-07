using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_10_01.ProtectionContainers;


internal class MabContainerExtendedInfoModel
{
    [JsonPropertyName("backupItemType")]
    public BackupItemTypeConstant? BackupItemType { get; set; }

    [JsonPropertyName("backupItems")]
    public List<string>? BackupItems { get; set; }

    [JsonPropertyName("lastBackupStatus")]
    public string? LastBackupStatus { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastRefreshedAt")]
    public DateTime? LastRefreshedAt { get; set; }

    [JsonPropertyName("policyName")]
    public string? PolicyName { get; set; }
}
