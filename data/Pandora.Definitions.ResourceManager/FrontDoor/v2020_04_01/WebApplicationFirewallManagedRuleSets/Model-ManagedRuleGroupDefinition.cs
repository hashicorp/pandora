using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.WebApplicationFirewallManagedRuleSets
{

    internal class ManagedRuleGroupDefinitionModel
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("ruleGroupName")]
        public string? RuleGroupName { get; set; }

        [JsonPropertyName("rules")]
        public List<ManagedRuleDefinitionModel>? Rules { get; set; }
    }
}
