// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserCalendarGroupCalendarCalendarView;

internal class CreateUserByIdCalendarGroupByIdCalendarByIdCalendarViewByIdDeclineRequestModel
{
    [JsonPropertyName("Comment")]
    public string? Comment { get; set; }

    [JsonPropertyName("ProposedNewTime")]
    public TimeSlotModel? ProposedNewTime { get; set; }

    [JsonPropertyName("SendResponse")]
    public bool? SendResponse { get; set; }
}
