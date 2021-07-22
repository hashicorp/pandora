using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.NetWorkRuleSets
{

    internal class NetworkRuleSetProperties
    {
        [JsonPropertyName("defaultAction")]
        public DefaultAction DefaultAction { get; set; }

        [JsonPropertyName("ipRules")]
        public List<NWRuleSetIpRules>? IpRules { get; set; }

        [JsonPropertyName("virtualNetworkRules")]
        public List<NWRuleSetVirtualNetworkRules>? VirtualNetworkRules { get; set; }
    }
}
