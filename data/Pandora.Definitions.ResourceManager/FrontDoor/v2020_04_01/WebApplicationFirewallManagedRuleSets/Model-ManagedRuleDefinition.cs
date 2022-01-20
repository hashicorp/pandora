using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.WebApplicationFirewallManagedRuleSets;


internal class ManagedRuleDefinitionModel
{
    [JsonPropertyName("defaultAction")]
    public ActionTypeConstant? DefaultAction { get; set; }

    [JsonPropertyName("defaultState")]
    public ManagedRuleEnabledStateConstant? DefaultState { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("ruleId")]
    public string? RuleId { get; set; }
}
