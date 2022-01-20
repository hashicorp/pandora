using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.NetworkRuleSets;


internal class NetworkRuleSetPropertiesModel
{
    [JsonPropertyName("defaultAction")]
    public DefaultActionConstant? DefaultAction { get; set; }

    [JsonPropertyName("ipRules")]
    public List<NWRuleSetIpRulesModel>? IpRules { get; set; }

    [JsonPropertyName("trustedServiceAccessEnabled")]
    public bool? TrustedServiceAccessEnabled { get; set; }

    [JsonPropertyName("virtualNetworkRules")]
    public List<NWRuleSetVirtualNetworkRulesModel>? VirtualNetworkRules { get; set; }
}
