// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ChannelModerationSettingsModel
{
    [JsonPropertyName("allowNewMessageFromBots")]
    public bool? AllowNewMessageFromBots { get; set; }

    [JsonPropertyName("allowNewMessageFromConnectors")]
    public bool? AllowNewMessageFromConnectors { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("replyRestriction")]
    public ChannelModerationSettingsReplyRestrictionConstant? ReplyRestriction { get; set; }

    [JsonPropertyName("userNewMessageRestriction")]
    public ChannelModerationSettingsUserNewMessageRestrictionConstant? UserNewMessageRestriction { get; set; }
}
