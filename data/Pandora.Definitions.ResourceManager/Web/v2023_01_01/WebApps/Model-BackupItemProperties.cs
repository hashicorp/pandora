using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.WebApps;


internal class BackupItemPropertiesModel
{
    [JsonPropertyName("blobName")]
    public string? BlobName { get; set; }

    [JsonPropertyName("correlationId")]
    public string? CorrelationId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("created")]
    public DateTime? Created { get; set; }

    [JsonPropertyName("databases")]
    public List<DatabaseBackupSettingModel>? Databases { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("finishedTimeStamp")]
    public DateTime? FinishedTimeStamp { get; set; }

    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastRestoreTimeStamp")]
    public DateTime? LastRestoreTimeStamp { get; set; }

    [JsonPropertyName("log")]
    public string? Log { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("scheduled")]
    public bool? Scheduled { get; set; }

    [JsonPropertyName("sizeInBytes")]
    public int? SizeInBytes { get; set; }

    [JsonPropertyName("status")]
    public BackupItemStatusConstant? Status { get; set; }

    [JsonPropertyName("storageAccountUrl")]
    public string? StorageAccountUrl { get; set; }

    [JsonPropertyName("websiteSizeInBytes")]
    public int? WebsiteSizeInBytes { get; set; }
}
