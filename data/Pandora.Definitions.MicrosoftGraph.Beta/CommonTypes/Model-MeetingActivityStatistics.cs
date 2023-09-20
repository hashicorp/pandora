// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MeetingActivityStatisticsModel
{
    [JsonPropertyName("activity")]
    public MeetingActivityStatisticsActivityConstant? Activity { get; set; }

    [JsonPropertyName("afterHours")]
    public string? AfterHours { get; set; }

    [JsonPropertyName("conflicting")]
    public string? Conflicting { get; set; }

    [JsonPropertyName("duration")]
    public string? Duration { get; set; }

    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("long")]
    public string? Long { get; set; }

    [JsonPropertyName("multitasking")]
    public string? Multitasking { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("organized")]
    public string? Organized { get; set; }

    [JsonPropertyName("recurring")]
    public string? Recurring { get; set; }

    [JsonPropertyName("startDate")]
    public DateTime? StartDate { get; set; }

    [JsonPropertyName("timeZoneUsed")]
    public string? TimeZoneUsed { get; set; }
}
