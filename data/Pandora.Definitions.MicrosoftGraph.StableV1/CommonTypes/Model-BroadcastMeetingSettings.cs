// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class BroadcastMeetingSettingsModel
{
    [JsonPropertyName("allowedAudience")]
    public BroadcastMeetingSettingsAllowedAudienceConstant? AllowedAudience { get; set; }

    [JsonPropertyName("captions")]
    public BroadcastMeetingCaptionSettingsModel? Captions { get; set; }

    [JsonPropertyName("isAttendeeReportEnabled")]
    public bool? IsAttendeeReportEnabled { get; set; }

    [JsonPropertyName("isQuestionAndAnswerEnabled")]
    public bool? IsQuestionAndAnswerEnabled { get; set; }

    [JsonPropertyName("isRecordingEnabled")]
    public bool? IsRecordingEnabled { get; set; }

    [JsonPropertyName("isVideoOnDemandEnabled")]
    public bool? IsVideoOnDemandEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
