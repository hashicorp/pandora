// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class CustomSecurityAttributeDefinitionModel
{
    [JsonPropertyName("allowedValues")]
    public List<AllowedValueModel>? AllowedValues { get; set; }

    [JsonPropertyName("attributeSet")]
    public string? AttributeSet { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isCollection")]
    public bool? IsCollection { get; set; }

    [JsonPropertyName("isSearchable")]
    public bool? IsSearchable { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("usePreDefinedValuesOnly")]
    public bool? UsePreDefinedValuesOnly { get; set; }
}
