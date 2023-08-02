// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class SecuritySensitivityLabelModel
{
    [JsonPropertyName("color")]
    public string? Color { get; set; }

    [JsonPropertyName("contentFormats")]
    public List<string>? ContentFormats { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("hasProtection")]
    public bool? HasProtection { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isActive")]
    public bool? IsActive { get; set; }

    [JsonPropertyName("isAppliable")]
    public bool? IsAppliable { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("parent")]
    public SensitivityLabelModel? Parent { get; set; }

    [JsonPropertyName("sensitivity")]
    public int? Sensitivity { get; set; }

    [JsonPropertyName("tooltip")]
    public string? Tooltip { get; set; }
}
