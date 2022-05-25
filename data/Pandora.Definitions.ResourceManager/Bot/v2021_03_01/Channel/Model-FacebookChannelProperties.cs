using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Bot.v2021_03_01.Channel;


internal class FacebookChannelPropertiesModel
{
    [JsonPropertyName("appId")]
    [Required]
    public string AppId { get; set; }

    [JsonPropertyName("appSecret")]
    public string? AppSecret { get; set; }

    [JsonPropertyName("callbackUrl")]
    public string? CallbackUrl { get; set; }

    [JsonPropertyName("isEnabled")]
    [Required]
    public bool IsEnabled { get; set; }

    [JsonPropertyName("pages")]
    public List<FacebookPageModel>? Pages { get; set; }

    [JsonPropertyName("verifyToken")]
    public string? VerifyToken { get; set; }
}
