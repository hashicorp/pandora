// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class IntegerRangeModel
{
    [JsonPropertyName("end")]
    public long? End { get; set; }

    [JsonPropertyName("maximum")]
    public long? Maximum { get; set; }

    [JsonPropertyName("minimum")]
    public long? Minimum { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("start")]
    public long? Start { get; set; }
}
