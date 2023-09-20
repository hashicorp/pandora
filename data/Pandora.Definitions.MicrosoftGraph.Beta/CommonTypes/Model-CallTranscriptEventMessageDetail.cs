// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CallTranscriptEventMessageDetailModel
{
    [JsonPropertyName("callId")]
    public string? CallId { get; set; }

    [JsonPropertyName("callTranscriptICalUid")]
    public string? CallTranscriptICalUid { get; set; }

    [JsonPropertyName("meetingOrganizer")]
    public IdentitySetModel? MeetingOrganizer { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
