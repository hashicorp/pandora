using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.ProtectionPolicies;


internal class WeeklyRetentionFormatModel
{
    [JsonPropertyName("daysOfTheWeek")]
    public List<DayOfWeekConstant>? DaysOfTheWeek { get; set; }

    [JsonPropertyName("weeksOfTheMonth")]
    public List<WeekOfMonthConstant>? WeeksOfTheMonth { get; set; }
}
