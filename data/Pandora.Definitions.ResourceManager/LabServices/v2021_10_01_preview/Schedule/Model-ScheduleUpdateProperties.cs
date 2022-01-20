using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.Schedule;


internal class ScheduleUpdatePropertiesModel
{
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("recurrencePattern")]
    public RecurrencePatternModel? RecurrencePattern { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startAt")]
    public DateTime? StartAt { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("stopAt")]
    public DateTime? StopAt { get; set; }

    [JsonPropertyName("timeZoneId")]
    public string? TimeZoneId { get; set; }
}
