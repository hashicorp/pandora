using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2020_01_13_preview.Schedule;


internal class SchedulePropertiesModel
{
    [JsonPropertyName("advancedSchedule")]
    public AdvancedScheduleModel? AdvancedSchedule { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationTime")]
    public DateTime? CreationTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expiryTime")]
    public DateTime? ExpiryTime { get; set; }

    [JsonPropertyName("expiryTimeOffsetMinutes")]
    public float? ExpiryTimeOffsetMinutes { get; set; }

    [JsonPropertyName("frequency")]
    public ScheduleFrequencyConstant? Frequency { get; set; }

    [JsonPropertyName("interval")]
    public object? Interval { get; set; }

    [JsonPropertyName("isEnabled")]
    public bool? IsEnabled { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedTime")]
    public DateTime? LastModifiedTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("nextRun")]
    public DateTime? NextRun { get; set; }

    [JsonPropertyName("nextRunOffsetMinutes")]
    public float? NextRunOffsetMinutes { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("startTimeOffsetMinutes")]
    public float? StartTimeOffsetMinutes { get; set; }

    [JsonPropertyName("timeZone")]
    public string? TimeZone { get; set; }
}
