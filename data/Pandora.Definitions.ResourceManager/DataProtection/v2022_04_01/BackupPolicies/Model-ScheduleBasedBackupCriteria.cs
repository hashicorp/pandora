using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_04_01.BackupPolicies;

[ValueForType("ScheduleBasedBackupCriteria")]
internal class ScheduleBasedBackupCriteriaModel : BackupCriteriaModel
{
    [JsonPropertyName("absoluteCriteria")]
    public List<AbsoluteMarkerConstant>? AbsoluteCriteria { get; set; }

    [JsonPropertyName("daysOfMonth")]
    public List<DayModel>? DaysOfMonth { get; set; }

    [JsonPropertyName("daysOfTheWeek")]
    public List<DayOfWeekConstant>? DaysOfTheWeek { get; set; }

    [JsonPropertyName("monthsOfYear")]
    public List<MonthConstant>? MonthsOfYear { get; set; }

    [JsonPropertyName("scheduleTimes")]
    public List<DateTime>? ScheduleTimes { get; set; }

    [JsonPropertyName("weeksOfTheMonth")]
    public List<WeekNumberConstant>? WeeksOfTheMonth { get; set; }
}
