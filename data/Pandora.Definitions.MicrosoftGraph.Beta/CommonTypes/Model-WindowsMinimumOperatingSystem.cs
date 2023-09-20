// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsMinimumOperatingSystemModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("v10_0")]
    public bool? V100 { get; set; }

    [JsonPropertyName("v10_1607")]
    public bool? V101607 { get; set; }

    [JsonPropertyName("v10_1703")]
    public bool? V101703 { get; set; }

    [JsonPropertyName("v10_1709")]
    public bool? V101709 { get; set; }

    [JsonPropertyName("v10_1803")]
    public bool? V101803 { get; set; }

    [JsonPropertyName("v10_1809")]
    public bool? V101809 { get; set; }

    [JsonPropertyName("v10_1903")]
    public bool? V101903 { get; set; }

    [JsonPropertyName("v10_1909")]
    public bool? V101909 { get; set; }

    [JsonPropertyName("v10_2004")]
    public bool? V102004 { get; set; }

    [JsonPropertyName("v10_21H1")]
    public bool? V1021H1 { get; set; }

    [JsonPropertyName("v10_2H20")]
    public bool? V102H20 { get; set; }

    [JsonPropertyName("v8_0")]
    public bool? V80 { get; set; }

    [JsonPropertyName("v8_1")]
    public bool? V81 { get; set; }
}
