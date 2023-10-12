// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class IosMinimumOperatingSystemModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("v10_0")]
    public bool? V100 { get; set; }

    [JsonPropertyName("v11_0")]
    public bool? V110 { get; set; }

    [JsonPropertyName("v12_0")]
    public bool? V120 { get; set; }

    [JsonPropertyName("v13_0")]
    public bool? V130 { get; set; }

    [JsonPropertyName("v14_0")]
    public bool? V140 { get; set; }

    [JsonPropertyName("v15_0")]
    public bool? V150 { get; set; }

    [JsonPropertyName("v16_0")]
    public bool? V160 { get; set; }

    [JsonPropertyName("v17_0")]
    public bool? V170 { get; set; }

    [JsonPropertyName("v8_0")]
    public bool? V80 { get; set; }

    [JsonPropertyName("v9_0")]
    public bool? V90 { get; set; }
}
