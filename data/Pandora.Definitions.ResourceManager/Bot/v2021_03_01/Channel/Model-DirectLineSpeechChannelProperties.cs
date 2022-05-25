using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Bot.v2021_03_01.Channel;


internal class DirectLineSpeechChannelPropertiesModel
{
    [JsonPropertyName("cognitiveServiceRegion")]
    [Required]
    public string CognitiveServiceRegion { get; set; }

    [JsonPropertyName("cognitiveServiceSubscriptionKey")]
    [Required]
    public string CognitiveServiceSubscriptionKey { get; set; }

    [JsonPropertyName("customSpeechModelId")]
    public string? CustomSpeechModelId { get; set; }

    [JsonPropertyName("customVoiceDeploymentId")]
    public string? CustomVoiceDeploymentId { get; set; }

    [JsonPropertyName("isDefaultBotForCogSvcAccount")]
    public bool? IsDefaultBotForCogSvcAccount { get; set; }

    [JsonPropertyName("isEnabled")]
    public bool? IsEnabled { get; set; }
}
