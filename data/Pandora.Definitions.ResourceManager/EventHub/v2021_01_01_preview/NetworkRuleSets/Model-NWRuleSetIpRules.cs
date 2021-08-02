using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.NetworkRuleSets
{

    internal class NWRuleSetIpRulesModel
    {
        [JsonPropertyName("action")]
        public NetworkRuleIPActionConstant? Action { get; set; }

        [JsonPropertyName("ipMask")]
        public string? IpMask { get; set; }
    }
}
