// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class BookingSchedulingPolicyModel
{
    [JsonPropertyName("allowStaffSelection")]
    public bool? AllowStaffSelection { get; set; }

    [JsonPropertyName("maximumAdvance")]
    public string? MaximumAdvance { get; set; }

    [JsonPropertyName("minimumLeadTime")]
    public string? MinimumLeadTime { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("sendConfirmationsToOwner")]
    public bool? SendConfirmationsToOwner { get; set; }

    [JsonPropertyName("timeSlotInterval")]
    public string? TimeSlotInterval { get; set; }
}
