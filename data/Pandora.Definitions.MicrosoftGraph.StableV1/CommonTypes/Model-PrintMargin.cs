// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class PrintMarginModel
{
    [JsonPropertyName("bottom")]
    public int? Bottom { get; set; }

    [JsonPropertyName("left")]
    public int? Left { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("right")]
    public int? Right { get; set; }

    [JsonPropertyName("top")]
    public int? Top { get; set; }
}
