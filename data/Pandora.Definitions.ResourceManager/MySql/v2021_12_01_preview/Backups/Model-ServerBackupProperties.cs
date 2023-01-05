using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MySql.v2021_12_01_preview.Backups;


internal class ServerBackupPropertiesModel
{
    [JsonPropertyName("backupType")]
    public string? BackupType { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("completedTime")]
    public DateTime? CompletedTime { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }
}
