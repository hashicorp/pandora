using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2021_10_01.SnapshotPolicy;


internal class SnapshotPolicyPropertiesModel
{
    [JsonPropertyName("dailySchedule")]
    public DailyScheduleModel? DailySchedule { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("hourlySchedule")]
    public HourlyScheduleModel? HourlySchedule { get; set; }

    [JsonPropertyName("monthlySchedule")]
    public MonthlyScheduleModel? MonthlySchedule { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("weeklySchedule")]
    public WeeklyScheduleModel? WeeklySchedule { get; set; }
}
