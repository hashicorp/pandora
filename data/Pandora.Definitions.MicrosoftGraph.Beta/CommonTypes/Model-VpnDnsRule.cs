// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class VpnDnsRuleModel
{
    [JsonPropertyName("autoTrigger")]
    public bool? AutoTrigger { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("persistent")]
    public bool? Persistent { get; set; }

    [JsonPropertyName("proxyServerUri")]
    public string? ProxyServerUri { get; set; }

    [JsonPropertyName("servers")]
    public List<string>? Servers { get; set; }
}
