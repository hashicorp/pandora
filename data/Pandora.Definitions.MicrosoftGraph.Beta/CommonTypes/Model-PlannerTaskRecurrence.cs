// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class PlannerTaskRecurrenceModel
{
    [JsonPropertyName("nextInSeriesTaskId")]
    public string? NextInSeriesTaskId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("occurrenceId")]
    public int? OccurrenceId { get; set; }

    [JsonPropertyName("previousInSeriesTaskId")]
    public string? PreviousInSeriesTaskId { get; set; }

    [JsonPropertyName("recurrenceStartDateTime")]
    public DateTime? RecurrenceStartDateTime { get; set; }

    [JsonPropertyName("schedule")]
    public PlannerRecurrenceScheduleModel? Schedule { get; set; }

    [JsonPropertyName("seriesId")]
    public string? SeriesId { get; set; }
}
