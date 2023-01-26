using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.FirewallPolicies;


internal class DnsSettingsModel
{
    [JsonPropertyName("enableProxy")]
    public bool? EnableProxy { get; set; }

    [JsonPropertyName("requireProxyForNetworkRules")]
    public bool? RequireProxyForNetworkRules { get; set; }

    [JsonPropertyName("servers")]
    public List<string>? Servers { get; set; }
}
