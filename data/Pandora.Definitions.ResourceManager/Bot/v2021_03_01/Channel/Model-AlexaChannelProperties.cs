using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Bot.v2021_03_01.Channel;


internal class AlexaChannelPropertiesModel
{
    [JsonPropertyName("alexaSkillId")]
    [Required]
    public string AlexaSkillId { get; set; }

    [JsonPropertyName("isEnabled")]
    [Required]
    public bool IsEnabled { get; set; }

    [JsonPropertyName("serviceEndpointUri")]
    public string? ServiceEndpointUri { get; set; }

    [JsonPropertyName("urlFragment")]
    public string? UrlFragment { get; set; }
}
