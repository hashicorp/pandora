// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class VpnOnDemandRuleModel
{
    [JsonPropertyName("action")]
    public VpnOnDemandRuleActionConstant? Action { get; set; }

    [JsonPropertyName("dnsSearchDomains")]
    public List<string>? DnsSearchDomains { get; set; }

    [JsonPropertyName("dnsServerAddressMatch")]
    public List<string>? DnsServerAddressMatch { get; set; }

    [JsonPropertyName("domainAction")]
    public VpnOnDemandRuleDomainActionConstant? DomainAction { get; set; }

    [JsonPropertyName("domains")]
    public List<string>? Domains { get; set; }

    [JsonPropertyName("interfaceTypeMatch")]
    public VpnOnDemandRuleInterfaceTypeMatchConstant? InterfaceTypeMatch { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("probeRequiredUrl")]
    public string? ProbeRequiredUrl { get; set; }

    [JsonPropertyName("probeUrl")]
    public string? ProbeUrl { get; set; }

    [JsonPropertyName("ssids")]
    public List<string>? Ssids { get; set; }
}
