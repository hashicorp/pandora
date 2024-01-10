using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ManagedDatabaseRestoreDetails;


internal class ManagedDatabaseRestoreDetailsBackupSetPropertiesModel
{
    [JsonPropertyName("backupSizeMB")]
    public int? BackupSizeMB { get; set; }

    [JsonPropertyName("firstStripeName")]
    public string? FirstStripeName { get; set; }

    [JsonPropertyName("numberOfStripes")]
    public int? NumberOfStripes { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("restoreFinishedTimestampUtc")]
    public DateTime? RestoreFinishedTimestampUtc { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("restoreStartedTimestampUtc")]
    public DateTime? RestoreStartedTimestampUtc { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
