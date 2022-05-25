using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Bot.v2021_03_01.Channel;


internal class ChannelSettingsModel
{
    [JsonPropertyName("botIconUrl")]
    public string? BotIconUrl { get; set; }

    [JsonPropertyName("botId")]
    public string? BotId { get; set; }

    [JsonPropertyName("channelDisplayName")]
    public string? ChannelDisplayName { get; set; }

    [JsonPropertyName("channelId")]
    public string? ChannelId { get; set; }

    [JsonPropertyName("disableLocalAuth")]
    public bool? DisableLocalAuth { get; set; }

    [JsonPropertyName("extensionKey1")]
    public string? ExtensionKey1 { get; set; }

    [JsonPropertyName("extensionKey2")]
    public string? ExtensionKey2 { get; set; }

    [JsonPropertyName("isEnabled")]
    public bool? IsEnabled { get; set; }

    [JsonPropertyName("sites")]
    public List<SiteModel>? Sites { get; set; }
}
