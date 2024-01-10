// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class Windows10AppsForceUpdateScheduleModel
{
    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("recurrence")]
    public Windows10AppsForceUpdateScheduleRecurrenceConstant? Recurrence { get; set; }

    [JsonPropertyName("runImmediatelyIfAfterStartDateTime")]
    public bool? RunImmediatelyIfAfterStartDateTime { get; set; }

    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }
}
