using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_04_01.BackupPolicies;

[ValueForType("SimpleSchedulePolicyV2")]
internal class SimpleSchedulePolicyV2Model : SchedulePolicyModel
{
    [JsonPropertyName("dailySchedule")]
    public DailyScheduleModel? DailySchedule { get; set; }

    [JsonPropertyName("hourlySchedule")]
    public HourlyScheduleModel? HourlySchedule { get; set; }

    [JsonPropertyName("scheduleRunFrequency")]
    public ScheduleRunTypeConstant? ScheduleRunFrequency { get; set; }

    [JsonPropertyName("weeklySchedule")]
    public WeeklyScheduleModel? WeeklySchedule { get; set; }
}
