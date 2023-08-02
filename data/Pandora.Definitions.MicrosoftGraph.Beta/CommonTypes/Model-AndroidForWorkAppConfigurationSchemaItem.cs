// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AndroidForWorkAppConfigurationSchemaItemModel
{
    [JsonPropertyName("dataType")]
    public AndroidForWorkAppConfigurationSchemaItemDataTypeConstant? DataType { get; set; }

    [JsonPropertyName("defaultBoolValue")]
    public bool? DefaultBoolValue { get; set; }

    [JsonPropertyName("defaultIntValue")]
    public int? DefaultIntValue { get; set; }

    [JsonPropertyName("defaultStringArrayValue")]
    public List<string>? DefaultStringArrayValue { get; set; }

    [JsonPropertyName("defaultStringValue")]
    public string? DefaultStringValue { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("schemaItemKey")]
    public string? SchemaItemKey { get; set; }

    [JsonPropertyName("selections")]
    public List<KeyValuePairModel>? Selections { get; set; }
}
