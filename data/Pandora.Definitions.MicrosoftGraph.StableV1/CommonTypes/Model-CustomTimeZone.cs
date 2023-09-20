// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class CustomTimeZoneModel
{
    [JsonPropertyName("bias")]
    public int? Bias { get; set; }

    [JsonPropertyName("daylightOffset")]
    public DaylightTimeZoneOffsetModel? DaylightOffset { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("standardOffset")]
    public StandardTimeZoneOffsetModel? StandardOffset { get; set; }
}
