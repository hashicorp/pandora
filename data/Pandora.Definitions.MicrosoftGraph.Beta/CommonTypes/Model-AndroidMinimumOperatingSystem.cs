// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AndroidMinimumOperatingSystemModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("v10_0")]
    public bool? V100 { get; set; }

    [JsonPropertyName("v11_0")]
    public bool? V110 { get; set; }

    [JsonPropertyName("v4_0")]
    public bool? V40 { get; set; }

    [JsonPropertyName("v4_0_3")]
    public bool? V403 { get; set; }

    [JsonPropertyName("v4_1")]
    public bool? V41 { get; set; }

    [JsonPropertyName("v4_2")]
    public bool? V42 { get; set; }

    [JsonPropertyName("v4_3")]
    public bool? V43 { get; set; }

    [JsonPropertyName("v4_4")]
    public bool? V44 { get; set; }

    [JsonPropertyName("v5_0")]
    public bool? V50 { get; set; }

    [JsonPropertyName("v5_1")]
    public bool? V51 { get; set; }

    [JsonPropertyName("v6_0")]
    public bool? V60 { get; set; }

    [JsonPropertyName("v7_0")]
    public bool? V70 { get; set; }

    [JsonPropertyName("v7_1")]
    public bool? V71 { get; set; }

    [JsonPropertyName("v8_0")]
    public bool? V80 { get; set; }

    [JsonPropertyName("v8_1")]
    public bool? V81 { get; set; }

    [JsonPropertyName("v9_0")]
    public bool? V90 { get; set; }
}
