using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Bot.v2021_03_01.BotHostSettings;


internal class HostSettingsResponseModel
{
    [JsonPropertyName("BotOpenIdMetadata")]
    public string? BotOpenIdMetadata { get; set; }

    [JsonPropertyName("OAuthUrl")]
    public string? OAuthUrl { get; set; }

    [JsonPropertyName("ToBotFromChannelOpenIdMetadataUrl")]
    public string? ToBotFromChannelOpenIdMetadataUrl { get; set; }

    [JsonPropertyName("ToBotFromChannelTokenIssuer")]
    public string? ToBotFromChannelTokenIssuer { get; set; }

    [JsonPropertyName("ToBotFromEmulatorOpenIdMetadataUrl")]
    public string? ToBotFromEmulatorOpenIdMetadataUrl { get; set; }

    [JsonPropertyName("ToChannelFromBotLoginUrl")]
    public string? ToChannelFromBotLoginUrl { get; set; }

    [JsonPropertyName("ToChannelFromBotOAuthScope")]
    public string? ToChannelFromBotOAuthScope { get; set; }

    [JsonPropertyName("ValidateAuthority")]
    public bool? ValidateAuthority { get; set; }
}
