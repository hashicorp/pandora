using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventHub.v2022_01_01_preview.SchemaRegistry;


internal class SchemaGroupPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdAtUtc")]
    public DateTime? CreatedAtUtc { get; set; }

    [JsonPropertyName("eTag")]
    public string? ETag { get; set; }

    [JsonPropertyName("groupProperties")]
    public Dictionary<string, string>? GroupProperties { get; set; }

    [JsonPropertyName("schemaCompatibility")]
    public SchemaCompatibilityConstant? SchemaCompatibility { get; set; }

    [JsonPropertyName("schemaType")]
    public SchemaTypeConstant? SchemaType { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("updatedAtUtc")]
    public DateTime? UpdatedAtUtc { get; set; }
}
