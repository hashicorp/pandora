using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ManagedDatabaseRestoreDetails;


internal class ManagedDatabaseRestoreDetailsPropertiesModel
{
    [JsonPropertyName("blockReason")]
    public string? BlockReason { get; set; }

    [JsonPropertyName("currentRestoringFileName")]
    public string? CurrentRestoringFileName { get; set; }

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

    [JsonPropertyName("numberOfFilesDetected")]
    public int? NumberOfFilesDetected { get; set; }

    [JsonPropertyName("percentCompleted")]
    public float? PercentCompleted { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("unrestorableFiles")]
    public List<string>? UnrestorableFiles { get; set; }
}
