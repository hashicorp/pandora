// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.User;

internal class CreateUserByIdFindMeetingTimeRequestModel
{
    [JsonPropertyName("attendees")]
    public List<AttendeeBaseModel>? Attendees { get; set; }

    [JsonPropertyName("isOrganizerOptional")]
    public bool? IsOrganizerOptional { get; set; }

    [JsonPropertyName("locationConstraint")]
    public LocationConstraintModel? LocationConstraint { get; set; }

    [JsonPropertyName("maxCandidates")]
    public int? MaxCandidates { get; set; }

    [JsonPropertyName("meetingDuration")]
    public string? MeetingDuration { get; set; }

    [JsonPropertyName("returnSuggestionReasons")]
    public bool? ReturnSuggestionReasons { get; set; }

    [JsonPropertyName("timeConstraint")]
    public TimeConstraintModel? TimeConstraint { get; set; }
}
