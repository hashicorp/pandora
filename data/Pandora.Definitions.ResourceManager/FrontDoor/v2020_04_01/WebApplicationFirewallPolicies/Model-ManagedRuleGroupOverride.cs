using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.WebApplicationFirewallPolicies
{

    internal class ManagedRuleGroupOverrideModel
    {
        [JsonPropertyName("exclusions")]
        public List<ManagedRuleExclusionModel>? Exclusions { get; set; }

        [JsonPropertyName("ruleGroupName")]
        [Required]
        public string RuleGroupName { get; set; }

        [JsonPropertyName("rules")]
        public List<ManagedRuleOverrideModel>? Rules { get; set; }
    }
}
