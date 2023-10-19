// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MacOSMinimumOperatingSystemModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("v10_10")]
    public bool? V1010 { get; set; }

    [JsonPropertyName("v10_11")]
    public bool? V1011 { get; set; }

    [JsonPropertyName("v10_12")]
    public bool? V1012 { get; set; }

    [JsonPropertyName("v10_13")]
    public bool? V1013 { get; set; }

    [JsonPropertyName("v10_14")]
    public bool? V1014 { get; set; }

    [JsonPropertyName("v10_15")]
    public bool? V1015 { get; set; }

    [JsonPropertyName("v10_7")]
    public bool? V107 { get; set; }

    [JsonPropertyName("v10_8")]
    public bool? V108 { get; set; }

    [JsonPropertyName("v10_9")]
    public bool? V109 { get; set; }

    [JsonPropertyName("v11_0")]
    public bool? V110 { get; set; }

    [JsonPropertyName("v12_0")]
    public bool? V120 { get; set; }

    [JsonPropertyName("v13_0")]
    public bool? V130 { get; set; }

    [JsonPropertyName("v14_0")]
    public bool? V140 { get; set; }
}
