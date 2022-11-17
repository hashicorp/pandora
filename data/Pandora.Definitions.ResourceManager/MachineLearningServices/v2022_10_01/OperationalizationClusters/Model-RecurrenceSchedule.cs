using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_10_01.OperationalizationClusters;


internal class RecurrenceScheduleModel
{
    [JsonPropertyName("hours")]
    [Required]
    public List<int> Hours { get; set; }

    [JsonPropertyName("minutes")]
    [Required]
    public List<int> Minutes { get; set; }

    [JsonPropertyName("monthDays")]
    public List<int>? MonthDays { get; set; }

    [JsonPropertyName("weekDays")]
    public List<WeekDayConstant>? WeekDays { get; set; }
}
