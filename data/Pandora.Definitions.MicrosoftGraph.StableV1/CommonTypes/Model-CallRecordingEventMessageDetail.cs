// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class CallRecordingEventMessageDetailModel
{
    [JsonPropertyName("callId")]
    public string? CallId { get; set; }

    [JsonPropertyName("callRecordingDisplayName")]
    public string? CallRecordingDisplayName { get; set; }

    [JsonPropertyName("callRecordingDuration")]
    public string? CallRecordingDuration { get; set; }

    [JsonPropertyName("callRecordingStatus")]
    public CallRecordingEventMessageDetailCallRecordingStatusConstant? CallRecordingStatus { get; set; }

    [JsonPropertyName("callRecordingUrl")]
    public string? CallRecordingUrl { get; set; }

    [JsonPropertyName("initiator")]
    public IdentitySetModel? Initiator { get; set; }

    [JsonPropertyName("meetingOrganizer")]
    public IdentitySetModel? MeetingOrganizer { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
