// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class TeamMessagingSettingsModel
{
    [JsonPropertyName("allowChannelMentions")]
    public bool? AllowChannelMentions { get; set; }

    [JsonPropertyName("allowOwnerDeleteMessages")]
    public bool? AllowOwnerDeleteMessages { get; set; }

    [JsonPropertyName("allowTeamMentions")]
    public bool? AllowTeamMentions { get; set; }

    [JsonPropertyName("allowUserDeleteMessages")]
    public bool? AllowUserDeleteMessages { get; set; }

    [JsonPropertyName("allowUserEditMessages")]
    public bool? AllowUserEditMessages { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
