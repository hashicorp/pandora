using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2022_04_01.WorkbooksAPIS;


internal class WorkbookPropertiesModel
{
    [JsonPropertyName("category")]
    [Required]
    public string Category { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    [Required]
    public string DisplayName { get; set; }

    [JsonPropertyName("revision")]
    public string? Revision { get; set; }

    [JsonPropertyName("serializedData")]
    [Required]
    public string SerializedData { get; set; }

    [JsonPropertyName("sourceId")]
    public string? SourceId { get; set; }

    [JsonPropertyName("storageUri")]
    public string? StorageUri { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("timeModified")]
    public DateTime? TimeModified { get; set; }

    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
