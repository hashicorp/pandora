using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Bot.v2021_03_01.Channel;


internal class MsTeamsChannelPropertiesModel
{
    [JsonPropertyName("acceptedTerms")]
    public bool? AcceptedTerms { get; set; }

    [JsonPropertyName("callingWebHook")]
    public string? CallingWebHook { get; set; }

    [JsonPropertyName("deploymentEnvironment")]
    public string? DeploymentEnvironment { get; set; }

    [JsonPropertyName("enableCalling")]
    public bool? EnableCalling { get; set; }

    [JsonPropertyName("incomingCallRoute")]
    public string? IncomingCallRoute { get; set; }

    [JsonPropertyName("isEnabled")]
    [Required]
    public bool IsEnabled { get; set; }
}
