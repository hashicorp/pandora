// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class ProtectOnlineMeetingActionModel
{
    [JsonPropertyName("allowedForwarders")]
    public ProtectOnlineMeetingActionAllowedForwardersConstant? AllowedForwarders { get; set; }

    [JsonPropertyName("allowedPresenters")]
    public ProtectOnlineMeetingActionAllowedPresentersConstant? AllowedPresenters { get; set; }

    [JsonPropertyName("isCopyToClipboardEnabled")]
    public bool? IsCopyToClipboardEnabled { get; set; }

    [JsonPropertyName("isLobbyEnabled")]
    public bool? IsLobbyEnabled { get; set; }

    [JsonPropertyName("lobbyBypassSettings")]
    public LobbyBypassSettingsModel? LobbyBypassSettings { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
