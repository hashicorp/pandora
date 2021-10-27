using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.FrontDoors
{

    internal class RulesEngineRuleModel
    {
        [JsonPropertyName("action")]
        [Required]
        public RulesEngineActionModel Action { get; set; }

        [JsonPropertyName("matchConditions")]
        public List<RulesEngineMatchConditionModel>? MatchConditions { get; set; }

        [JsonPropertyName("matchProcessingBehavior")]
        public MatchProcessingBehaviorConstant? MatchProcessingBehavior { get; set; }

        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }

        [JsonPropertyName("priority")]
        [Required]
        public int Priority { get; set; }
    }
}
