// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class MeetingPolicyUpdatedEventMessageDetailModel
{
    [JsonPropertyName("initiator")]
    public IdentitySetModel? Initiator { get; set; }

    [JsonPropertyName("meetingChatEnabled")]
    public bool? MeetingChatEnabled { get; set; }

    [JsonPropertyName("meetingChatId")]
    public string? MeetingChatId { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
