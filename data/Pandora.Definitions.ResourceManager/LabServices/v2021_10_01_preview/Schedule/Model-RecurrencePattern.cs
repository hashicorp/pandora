using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.Schedule;


internal class RecurrencePatternModel
{
    [JsonPropertyName("expirationDate")]
    [Required]
    public string ExpirationDate { get; set; }

    [JsonPropertyName("frequency")]
    [Required]
    public RecurrenceFrequencyConstant Frequency { get; set; }

    [JsonPropertyName("interval")]
    public int? Interval { get; set; }

    [JsonPropertyName("weekDays")]
    public List<WeekDayConstant>? WeekDays { get; set; }
}
