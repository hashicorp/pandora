using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.LongTermRetentionBackups;


internal class LongTermRetentionBackupPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("backupExpirationTime")]
    public DateTime? BackupExpirationTime { get; set; }

    [JsonPropertyName("backupStorageRedundancy")]
    public BackupStorageRedundancyConstant? BackupStorageRedundancy { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("backupTime")]
    public DateTime? BackupTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("databaseDeletionTime")]
    public DateTime? DatabaseDeletionTime { get; set; }

    [JsonPropertyName("databaseName")]
    public string? DatabaseName { get; set; }

    [JsonPropertyName("requestedBackupStorageRedundancy")]
    public BackupStorageRedundancyConstant? RequestedBackupStorageRedundancy { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("serverCreateTime")]
    public DateTime? ServerCreateTime { get; set; }

    [JsonPropertyName("serverName")]
    public string? ServerName { get; set; }
}
