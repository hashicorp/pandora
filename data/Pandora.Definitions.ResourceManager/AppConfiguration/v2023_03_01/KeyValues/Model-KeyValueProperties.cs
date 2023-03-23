using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2023_03_01.KeyValues;


internal class KeyValuePropertiesModel
{
    [JsonPropertyName("contentType")]
    public string? ContentType { get; set; }

    [JsonPropertyName("eTag")]
    public string? ETag { get; set; }

    [JsonPropertyName("key")]
    public string? Key { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModified")]
    public DateTime? LastModified { get; set; }

    [JsonPropertyName("locked")]
    public bool? Locked { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}
