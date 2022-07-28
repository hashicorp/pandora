using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.FirewallPolicies;


internal class ExplicitProxySettingsModel
{
    [JsonPropertyName("enableExplicitProxy")]
    public bool? EnableExplicitProxy { get; set; }

    [JsonPropertyName("httpPort")]
    public int? HttpPort { get; set; }

    [JsonPropertyName("httpsPort")]
    public int? HttpsPort { get; set; }

    [JsonPropertyName("pacFile")]
    public string? PacFile { get; set; }

    [JsonPropertyName("pacFilePort")]
    public int? PacFilePort { get; set; }
}
