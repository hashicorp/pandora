// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class MeetingTimeSuggestionModel
{
    [JsonPropertyName("attendeeAvailability")]
    public List<AttendeeAvailabilityModel>? AttendeeAvailability { get; set; }

    [JsonPropertyName("locations")]
    public List<LocationModel>? Locations { get; set; }

    [JsonPropertyName("meetingTimeSlot")]
    public TimeSlotModel? MeetingTimeSlot { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("order")]
    public int? Order { get; set; }

    [JsonPropertyName("organizerAvailability")]
    public MeetingTimeSuggestionOrganizerAvailabilityConstant? OrganizerAvailability { get; set; }

    [JsonPropertyName("suggestionReason")]
    public string? SuggestionReason { get; set; }
}
