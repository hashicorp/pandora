// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupCalendarEvent;

internal class CreateGroupByIdCalendarEventByIdSnoozeReminderRequestModel
{
    [JsonPropertyName("NewReminderTime")]
    public DateTimeTimeZoneModel? NewReminderTime { get; set; }
}
