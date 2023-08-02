// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class EmailActivityStatisticsModel
{
    [JsonPropertyName("activity")]
    public AnalyticsActivityTypeConstant? Activity { get; set; }

    [JsonPropertyName("afterHours")]
    public string? AfterHours { get; set; }

    [JsonPropertyName("duration")]
    public string? Duration { get; set; }

    [JsonPropertyName("endDate")]
    public DateTime? EndDate { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("readEmail")]
    public string? ReadEmail { get; set; }

    [JsonPropertyName("sentEmail")]
    public string? SentEmail { get; set; }

    [JsonPropertyName("startDate")]
    public DateTime? StartDate { get; set; }

    [JsonPropertyName("timeZoneUsed")]
    public string? TimeZoneUsed { get; set; }
}
