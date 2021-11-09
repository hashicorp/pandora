using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.CognitiveServicesAccounts
{

    internal class NetworkRuleSetModel
    {
        [JsonPropertyName("defaultAction")]
        public NetworkRuleActionConstant? DefaultAction { get; set; }

        [JsonPropertyName("ipRules")]
        public List<IpRuleModel>? IpRules { get; set; }

        [JsonPropertyName("virtualNetworkRules")]
        public List<VirtualNetworkRuleModel>? VirtualNetworkRules { get; set; }
    }
}
