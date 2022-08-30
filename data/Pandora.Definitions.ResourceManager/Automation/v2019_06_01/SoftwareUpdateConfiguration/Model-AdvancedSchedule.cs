using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.SoftwareUpdateConfiguration;


internal class AdvancedScheduleModel
{
    [JsonPropertyName("monthDays")]
    public List<int>? MonthDays { get; set; }

    [JsonPropertyName("monthlyOccurrences")]
    public List<AdvancedScheduleMonthlyOccurrenceModel>? MonthlyOccurrences { get; set; }

    [JsonPropertyName("weekDays")]
    public List<string>? WeekDays { get; set; }
}
