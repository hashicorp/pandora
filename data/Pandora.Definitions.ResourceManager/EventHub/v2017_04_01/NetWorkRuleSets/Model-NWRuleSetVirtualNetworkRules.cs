using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.NetWorkRuleSets
{

    internal class NWRuleSetVirtualNetworkRules
    {
        [JsonPropertyName("ignoreMissingVnetServiceEndpoint")]
        public bool IgnoreMissingVnetServiceEndpoint { get; set; }

        [JsonPropertyName("subnet")]
        public Subnet? Subnet { get; set; }
    }
}
