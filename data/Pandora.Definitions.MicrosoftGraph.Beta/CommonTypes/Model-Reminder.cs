// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ReminderModel
{
    [JsonPropertyName("changeKey")]
    public string? ChangeKey { get; set; }

    [JsonPropertyName("eventEndTime")]
    public DateTimeTimeZoneModel? EventEndTime { get; set; }

    [JsonPropertyName("eventId")]
    public string? EventId { get; set; }

    [JsonPropertyName("eventLocation")]
    public LocationModel? EventLocation { get; set; }

    [JsonPropertyName("eventStartTime")]
    public DateTimeTimeZoneModel? EventStartTime { get; set; }

    [JsonPropertyName("eventSubject")]
    public string? EventSubject { get; set; }

    [JsonPropertyName("eventWebLink")]
    public string? EventWebLink { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("reminderFireTime")]
    public DateTimeTimeZoneModel? ReminderFireTime { get; set; }
}
