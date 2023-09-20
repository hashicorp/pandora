// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class Windows81VpnProxyServerModel
{
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("automaticConfigurationScriptUrl")]
    public string? AutomaticConfigurationScriptUrl { get; set; }

    [JsonPropertyName("automaticallyDetectProxySettings")]
    public bool? AutomaticallyDetectProxySettings { get; set; }

    [JsonPropertyName("bypassProxyServerForLocalAddress")]
    public bool? BypassProxyServerForLocalAddress { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("port")]
    public int? Port { get; set; }
}
