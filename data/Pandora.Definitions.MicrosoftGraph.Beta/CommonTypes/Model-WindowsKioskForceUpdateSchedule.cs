// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsKioskForceUpdateScheduleModel
{
    [JsonPropertyName("dayofMonth")]
    public int? DayofMonth { get; set; }

    [JsonPropertyName("dayofWeek")]
    public WindowsKioskForceUpdateScheduleDayofWeekConstant? DayofWeek { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("recurrence")]
    public WindowsKioskForceUpdateScheduleRecurrenceConstant? Recurrence { get; set; }

    [JsonPropertyName("runImmediatelyIfAfterStartDateTime")]
    public bool? RunImmediatelyIfAfterStartDateTime { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }
}
