using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.WebApplicationFirewallPolicies
{

    internal class ManagedRuleSetModel
    {
        [JsonPropertyName("exclusions")]
        public List<ManagedRuleExclusionModel>? Exclusions { get; set; }

        [JsonPropertyName("ruleGroupOverrides")]
        public List<ManagedRuleGroupOverrideModel>? RuleGroupOverrides { get; set; }

        [JsonPropertyName("ruleSetType")]
        [Required]
        public string RuleSetType { get; set; }

        [JsonPropertyName("ruleSetVersion")]
        [Required]
        public string RuleSetVersion { get; set; }
    }
}
