// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class ChatMessageMentionedIdentitySetModel
{
    [JsonPropertyName("application")]
    public IdentityModel? Application { get; set; }

    [JsonPropertyName("conversation")]
    public TeamworkConversationIdentityModel? Conversation { get; set; }

    [JsonPropertyName("device")]
    public IdentityModel? Device { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("user")]
    public IdentityModel? User { get; set; }
}
