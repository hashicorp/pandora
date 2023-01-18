using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.WorkflowTriggers;


internal class RecurrenceScheduleModel
{
    [JsonPropertyName("hours")]
    public List<int>? Hours { get; set; }

    [JsonPropertyName("minutes")]
    public List<int>? Minutes { get; set; }

    [JsonPropertyName("monthDays")]
    public List<int>? MonthDays { get; set; }

    [JsonPropertyName("monthlyOccurrences")]
    public List<RecurrenceScheduleOccurrenceModel>? MonthlyOccurrences { get; set; }

    [JsonPropertyName("weekDays")]
    public List<DaysOfWeekConstant>? WeekDays { get; set; }
}
