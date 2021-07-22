using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.NetworkRuleSets
{

    internal class NWRuleSetVirtualNetworkRules
    {
        [JsonPropertyName("ignoreMissingVnetServiceEndpoint")]
        public bool IgnoreMissingVnetServiceEndpoint { get; set; }

        [JsonPropertyName("subnet")]
        public Subnet? Subnet { get; set; }
    }
}
