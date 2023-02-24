using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.FileImports;


internal class FileImportPropertiesModel
{
    [JsonPropertyName("contentType")]
    [Required]
    public FileImportContentTypeConstant ContentType { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdTimeUTC")]
    public DateTime? CreatedTimeUTC { get; set; }

    [JsonPropertyName("errorFile")]
    public FileMetadataModel? ErrorFile { get; set; }

    [JsonPropertyName("errorsPreview")]
    public List<ValidationErrorModel>? ErrorsPreview { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("filesValidUntilTimeUTC")]
    public DateTime? FilesValidUntilTimeUTC { get; set; }

    [JsonPropertyName("importFile")]
    [Required]
    public FileMetadataModel ImportFile { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("importValidUntilTimeUTC")]
    public DateTime? ImportValidUntilTimeUTC { get; set; }

    [JsonPropertyName("ingestedRecordCount")]
    public int? IngestedRecordCount { get; set; }

    [JsonPropertyName("ingestionMode")]
    [Required]
    public IngestionModeConstant IngestionMode { get; set; }

    [JsonPropertyName("source")]
    [Required]
    public string Source { get; set; }

    [JsonPropertyName("state")]
    public FileImportStateConstant? State { get; set; }

    [JsonPropertyName("totalRecordCount")]
    public int? TotalRecordCount { get; set; }

    [JsonPropertyName("validRecordCount")]
    public int? ValidRecordCount { get; set; }
}
