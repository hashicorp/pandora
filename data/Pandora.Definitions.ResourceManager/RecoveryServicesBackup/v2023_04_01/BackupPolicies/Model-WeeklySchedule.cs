using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_04_01.BackupPolicies;


internal class WeeklyScheduleModel
{
    [JsonPropertyName("scheduleRunDays")]
    public List<DayOfWeekConstant>? ScheduleRunDays { get; set; }

    [JsonPropertyName("scheduleRunTimes")]
    public List<DateTime>? ScheduleRunTimes { get; set; }
}
