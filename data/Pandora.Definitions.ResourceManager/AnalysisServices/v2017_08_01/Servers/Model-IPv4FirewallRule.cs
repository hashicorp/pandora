using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.Servers;


internal class IPv4FirewallRuleModel
{
    [JsonPropertyName("firewallRuleName")]
    public string? FirewallRuleName { get; set; }

    [JsonPropertyName("rangeEnd")]
    public string? RangeEnd { get; set; }

    [JsonPropertyName("rangeStart")]
    public string? RangeStart { get; set; }
}
