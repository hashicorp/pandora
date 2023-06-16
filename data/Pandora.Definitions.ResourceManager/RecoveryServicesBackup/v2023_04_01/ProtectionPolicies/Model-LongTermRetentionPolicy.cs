using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_04_01.ProtectionPolicies;

[ValueForType("LongTermRetentionPolicy")]
internal class LongTermRetentionPolicyModel : RetentionPolicyModel
{
    [JsonPropertyName("dailySchedule")]
    public DailyRetentionScheduleModel? DailySchedule { get; set; }

    [JsonPropertyName("monthlySchedule")]
    public MonthlyRetentionScheduleModel? MonthlySchedule { get; set; }

    [JsonPropertyName("weeklySchedule")]
    public WeeklyRetentionScheduleModel? WeeklySchedule { get; set; }

    [JsonPropertyName("yearlySchedule")]
    public YearlyRetentionScheduleModel? YearlySchedule { get; set; }
}
