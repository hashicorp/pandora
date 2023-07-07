using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_03_01_preview.LongTermRetentionBackup;


internal class LtrBackupOperationResponsePropertiesModel
{
    [JsonPropertyName("backupMetadata")]
    public string? BackupMetadata { get; set; }

    [JsonPropertyName("backupName")]
    public string? BackupName { get; set; }

    [JsonPropertyName("dataTransferredInBytes")]
    public int? DataTransferredInBytes { get; set; }

    [JsonPropertyName("datasourceSizeInBytes")]
    public int? DatasourceSizeInBytes { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endTime")]
    public DateTime? EndTime { get; set; }

    [JsonPropertyName("errorCode")]
    public string? ErrorCode { get; set; }

    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }

    [JsonPropertyName("percentComplete")]
    public float? PercentComplete { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    [Required]
    public DateTime StartTime { get; set; }

    [JsonPropertyName("status")]
    [Required]
    public ExecutionStatusConstant Status { get; set; }
}
