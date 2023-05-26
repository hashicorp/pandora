using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.ManagedDatabaseRestoreDetails;


internal class ManagedDatabaseRestoreDetailsPropertiesModel
{
    [JsonPropertyName("blockReason")]
    public string? BlockReason { get; set; }

    [JsonPropertyName("currentBackupType")]
    public string? CurrentBackupType { get; set; }

    [JsonPropertyName("currentRestorePlanSizeMB")]
    public int? CurrentRestorePlanSizeMB { get; set; }

    [JsonPropertyName("currentRestoredSizeMB")]
    public int? CurrentRestoredSizeMB { get; set; }

    [JsonPropertyName("currentRestoringFileName")]
    public string? CurrentRestoringFileName { get; set; }

    [JsonPropertyName("diffBackupSets")]
    public List<ManagedDatabaseRestoreDetailsBackupSetPropertiesModel>? DiffBackupSets { get; set; }

    [JsonPropertyName("fullBackupSets")]
    public List<ManagedDatabaseRestoreDetailsBackupSetPropertiesModel>? FullBackupSets { get; set; }

    [JsonPropertyName("lastRestoredFileName")]
    public string? LastRestoredFileName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastRestoredFileTime")]
    public DateTime? LastRestoredFileTime { get; set; }

    [JsonPropertyName("lastUploadedFileName")]
    public string? LastUploadedFileName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUploadedFileTime")]
    public DateTime? LastUploadedFileTime { get; set; }

    [JsonPropertyName("logBackupSets")]
    public List<ManagedDatabaseRestoreDetailsBackupSetPropertiesModel>? LogBackupSets { get; set; }

    [JsonPropertyName("numberOfFilesDetected")]
    public int? NumberOfFilesDetected { get; set; }

    [JsonPropertyName("numberOfFilesQueued")]
    public int? NumberOfFilesQueued { get; set; }

    [JsonPropertyName("numberOfFilesRestored")]
    public int? NumberOfFilesRestored { get; set; }

    [JsonPropertyName("numberOfFilesRestoring")]
    public int? NumberOfFilesRestoring { get; set; }

    [JsonPropertyName("numberOfFilesSkipped")]
    public int? NumberOfFilesSkipped { get; set; }

    [JsonPropertyName("numberOfFilesUnrestorable")]
    public int? NumberOfFilesUnrestorable { get; set; }

    [JsonPropertyName("percentCompleted")]
    public int? PercentCompleted { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("unrestorableFiles")]
    public List<ManagedDatabaseRestoreDetailsUnrestorableFilePropertiesModel>? UnrestorableFiles { get; set; }
}
