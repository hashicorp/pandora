using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.WebApplicationFirewallPolicies;


internal class ManagedRuleExclusionModel
{
    [JsonPropertyName("matchVariable")]
    [Required]
    public ManagedRuleExclusionMatchVariableConstant MatchVariable { get; set; }

    [JsonPropertyName("selector")]
    [Required]
    public string Selector { get; set; }

    [JsonPropertyName("selectorMatchOperator")]
    [Required]
    public ManagedRuleExclusionSelectorMatchOperatorConstant SelectorMatchOperator { get; set; }
}
