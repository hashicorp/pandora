// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class StandardTimeZoneOffsetModel
{
    [JsonPropertyName("dayOccurrence")]
    public int? DayOccurrence { get; set; }

    [JsonPropertyName("dayOfWeek")]
    public StandardTimeZoneOffsetDayOfWeekConstant? DayOfWeek { get; set; }

    [JsonPropertyName("month")]
    public int? Month { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("time")]
    public DateTime? Time { get; set; }

    [JsonPropertyName("year")]
    public int? Year { get; set; }
}
