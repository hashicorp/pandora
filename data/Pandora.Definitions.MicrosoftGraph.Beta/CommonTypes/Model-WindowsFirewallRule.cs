// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsFirewallRuleModel
{
    [JsonPropertyName("action")]
    public WindowsFirewallRuleActionConstant? Action { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("edgeTraversal")]
    public WindowsFirewallRuleEdgeTraversalConstant? EdgeTraversal { get; set; }

    [JsonPropertyName("filePath")]
    public string? FilePath { get; set; }

    [JsonPropertyName("interfaceTypes")]
    public WindowsFirewallRuleInterfaceTypesConstant? InterfaceTypes { get; set; }

    [JsonPropertyName("localAddressRanges")]
    public List<string>? LocalAddressRanges { get; set; }

    [JsonPropertyName("localPortRanges")]
    public List<string>? LocalPortRanges { get; set; }

    [JsonPropertyName("localUserAuthorizations")]
    public string? LocalUserAuthorizations { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("packageFamilyName")]
    public string? PackageFamilyName { get; set; }

    [JsonPropertyName("profileTypes")]
    public WindowsFirewallRuleProfileTypesConstant? ProfileTypes { get; set; }

    [JsonPropertyName("protocol")]
    public int? Protocol { get; set; }

    [JsonPropertyName("remoteAddressRanges")]
    public List<string>? RemoteAddressRanges { get; set; }

    [JsonPropertyName("remotePortRanges")]
    public List<string>? RemotePortRanges { get; set; }

    [JsonPropertyName("serviceName")]
    public string? ServiceName { get; set; }

    [JsonPropertyName("trafficDirection")]
    public WindowsFirewallRuleTrafficDirectionConstant? TrafficDirection { get; set; }
}
