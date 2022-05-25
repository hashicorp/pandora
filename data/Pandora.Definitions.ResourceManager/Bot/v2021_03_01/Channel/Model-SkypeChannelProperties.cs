using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Bot.v2021_03_01.Channel;


internal class SkypeChannelPropertiesModel
{
    [JsonPropertyName("callingWebHook")]
    public string? CallingWebHook { get; set; }

    [JsonPropertyName("enableCalling")]
    public bool? EnableCalling { get; set; }

    [JsonPropertyName("enableGroups")]
    public bool? EnableGroups { get; set; }

    [JsonPropertyName("enableMediaCards")]
    public bool? EnableMediaCards { get; set; }

    [JsonPropertyName("enableMessaging")]
    public bool? EnableMessaging { get; set; }

    [JsonPropertyName("enableScreenSharing")]
    public bool? EnableScreenSharing { get; set; }

    [JsonPropertyName("enableVideo")]
    public bool? EnableVideo { get; set; }

    [JsonPropertyName("groupsMode")]
    public string? GroupsMode { get; set; }

    [JsonPropertyName("incomingCallRoute")]
    public string? IncomingCallRoute { get; set; }

    [JsonPropertyName("isEnabled")]
    [Required]
    public bool IsEnabled { get; set; }
}
