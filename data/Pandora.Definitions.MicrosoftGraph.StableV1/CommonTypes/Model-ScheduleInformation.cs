// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ScheduleInformationModel
{
    [JsonPropertyName("availabilityView")]
    public string? AvailabilityView { get; set; }

    [JsonPropertyName("error")]
    public FreeBusyErrorModel? Error { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("scheduleId")]
    public string? ScheduleId { get; set; }

    [JsonPropertyName("scheduleItems")]
    public List<ScheduleItemModel>? ScheduleItems { get; set; }

    [JsonPropertyName("workingHours")]
    public WorkingHoursModel? WorkingHours { get; set; }
}
