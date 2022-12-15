using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.HybridCompute.v2022_11_10.Machines;


internal class AgentConfigurationModel
{
    [JsonPropertyName("configMode")]
    public AgentConfigurationModeConstant? ConfigMode { get; set; }

    [JsonPropertyName("extensionsAllowList")]
    public List<ConfigurationExtensionModel>? ExtensionsAllowList { get; set; }

    [JsonPropertyName("extensionsBlockList")]
    public List<ConfigurationExtensionModel>? ExtensionsBlockList { get; set; }

    [JsonPropertyName("extensionsEnabled")]
    public string? ExtensionsEnabled { get; set; }

    [JsonPropertyName("guestConfigurationEnabled")]
    public string? GuestConfigurationEnabled { get; set; }

    [JsonPropertyName("incomingConnectionsPorts")]
    public List<string>? IncomingConnectionsPorts { get; set; }

    [JsonPropertyName("proxyBypass")]
    public List<string>? ProxyBypass { get; set; }

    [JsonPropertyName("proxyUrl")]
    public string? ProxyUrl { get; set; }
}
