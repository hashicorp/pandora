using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.Servers;


internal class IPv4FirewallSettingsModel
{
    [JsonPropertyName("enablePowerBIService")]
    public bool? EnablePowerBIService { get; set; }

    [JsonPropertyName("firewallRules")]
    public List<IPv4FirewallRuleModel>? FirewallRules { get; set; }
}
