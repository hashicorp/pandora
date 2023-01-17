using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Formulas;


internal class ScheduleCreationParameterPropertiesModel
{
    [JsonPropertyName("dailyRecurrence")]
    public DayDetailsModel? DailyRecurrence { get; set; }

    [JsonPropertyName("hourlyRecurrence")]
    public HourDetailsModel? HourlyRecurrence { get; set; }

    [JsonPropertyName("notificationSettings")]
    public NotificationSettingsModel? NotificationSettings { get; set; }

    [JsonPropertyName("status")]
    public EnableStatusConstant? Status { get; set; }

    [JsonPropertyName("targetResourceId")]
    public string? TargetResourceId { get; set; }

    [JsonPropertyName("taskType")]
    public string? TaskType { get; set; }

    [JsonPropertyName("timeZoneId")]
    public string? TimeZoneId { get; set; }

    [JsonPropertyName("weeklyRecurrence")]
    public WeekDetailsModel? WeeklyRecurrence { get; set; }
}
