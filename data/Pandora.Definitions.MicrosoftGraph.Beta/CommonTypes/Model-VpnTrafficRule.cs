// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class VpnTrafficRuleModel
{
    [JsonPropertyName("appId")]
    public string? AppId { get; set; }

    [JsonPropertyName("appType")]
    public VpnTrafficRuleAppTypeConstant? AppType { get; set; }

    [JsonPropertyName("claims")]
    public string? Claims { get; set; }

    [JsonPropertyName("localAddressRanges")]
    public List<IPv4RangeModel>? LocalAddressRanges { get; set; }

    [JsonPropertyName("localPortRanges")]
    public List<NumberRangeModel>? LocalPortRanges { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("protocols")]
    public int? Protocols { get; set; }

    [JsonPropertyName("remoteAddressRanges")]
    public List<IPv4RangeModel>? RemoteAddressRanges { get; set; }

    [JsonPropertyName("remotePortRanges")]
    public List<NumberRangeModel>? RemotePortRanges { get; set; }

    [JsonPropertyName("routingPolicyType")]
    public VpnTrafficRuleRoutingPolicyTypeConstant? RoutingPolicyType { get; set; }

    [JsonPropertyName("vpnTrafficDirection")]
    public VpnTrafficDirectionConstant? VpnTrafficDirection { get; set; }
}
