// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CustomUpdateTimeWindowModel
{
    [JsonPropertyName("endDay")]
    public CustomUpdateTimeWindowEndDayConstant? EndDay { get; set; }

    [JsonPropertyName("endTime")]
    public DateTime? EndTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("startDay")]
    public CustomUpdateTimeWindowStartDayConstant? StartDay { get; set; }

    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }
}
