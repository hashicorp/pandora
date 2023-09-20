// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class InvitationParticipantInfoModel
{
    [JsonPropertyName("hidden")]
    public bool? Hidden { get; set; }

    [JsonPropertyName("identity")]
    public IdentitySetModel? Identity { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("participantId")]
    public string? ParticipantId { get; set; }

    [JsonPropertyName("removeFromDefaultAudioRoutingGroup")]
    public bool? RemoveFromDefaultAudioRoutingGroup { get; set; }

    [JsonPropertyName("replacesCallId")]
    public string? ReplacesCallId { get; set; }
}
