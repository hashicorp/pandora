using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.BackupPolicies;

[ValueForType("SimpleSchedulePolicy")]
internal class SimpleSchedulePolicyModel : SchedulePolicyModel
{
    [JsonPropertyName("hourlySchedule")]
    public HourlyScheduleModel? HourlySchedule { get; set; }

    [JsonPropertyName("scheduleRunDays")]
    public List<DayOfWeekConstant>? ScheduleRunDays { get; set; }

    [JsonPropertyName("scheduleRunFrequency")]
    public ScheduleRunTypeConstant? ScheduleRunFrequency { get; set; }

    [JsonPropertyName("scheduleRunTimes")]
    public List<DateTime>? ScheduleRunTimes { get; set; }

    [JsonPropertyName("scheduleWeeklyFrequency")]
    public int? ScheduleWeeklyFrequency { get; set; }
}
