using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.NetworkRuleSets
{

    internal class NWRuleSetIpRules
    {
        [JsonPropertyName("action")]
        public NetworkRuleIPAction Action { get; set; }

        [JsonPropertyName("ipMask")]
        public string? IpMask { get; set; }
    }
}
