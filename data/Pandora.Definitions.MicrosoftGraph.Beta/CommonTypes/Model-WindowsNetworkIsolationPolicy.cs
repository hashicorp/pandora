// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class WindowsNetworkIsolationPolicyModel
{
    [JsonPropertyName("enterpriseCloudResources")]
    public List<ProxiedDomainModel>? EnterpriseCloudResources { get; set; }

    [JsonPropertyName("enterpriseIPRanges")]
    public List<IpRangeModel>? EnterpriseIPRanges { get; set; }

    [JsonPropertyName("enterpriseIPRangesAreAuthoritative")]
    public bool? EnterpriseIPRangesAreAuthoritative { get; set; }

    [JsonPropertyName("enterpriseInternalProxyServers")]
    public List<string>? EnterpriseInternalProxyServers { get; set; }

    [JsonPropertyName("enterpriseNetworkDomainNames")]
    public List<string>? EnterpriseNetworkDomainNames { get; set; }

    [JsonPropertyName("enterpriseProxyServers")]
    public List<string>? EnterpriseProxyServers { get; set; }

    [JsonPropertyName("enterpriseProxyServersAreAuthoritative")]
    public bool? EnterpriseProxyServersAreAuthoritative { get; set; }

    [JsonPropertyName("neutralDomainResources")]
    public List<string>? NeutralDomainResources { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
