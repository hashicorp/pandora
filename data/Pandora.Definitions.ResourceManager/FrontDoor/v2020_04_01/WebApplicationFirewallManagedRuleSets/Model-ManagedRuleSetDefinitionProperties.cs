using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.WebApplicationFirewallManagedRuleSets;


internal class ManagedRuleSetDefinitionPropertiesModel
{
    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("ruleGroups")]
    public List<ManagedRuleGroupDefinitionModel>? RuleGroups { get; set; }

    [JsonPropertyName("ruleSetId")]
    public string? RuleSetId { get; set; }

    [JsonPropertyName("ruleSetType")]
    public string? RuleSetType { get; set; }

    [JsonPropertyName("ruleSetVersion")]
    public string? RuleSetVersion { get; set; }
}
