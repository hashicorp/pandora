using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.WebApplicationFirewallPolicies;


internal class CustomRuleModel
{
    [JsonPropertyName("action")]
    [Required]
    public ActionTypeConstant Action { get; set; }

    [JsonPropertyName("enabledState")]
    public CustomRuleEnabledStateConstant? EnabledState { get; set; }

    [JsonPropertyName("matchConditions")]
    [Required]
    public List<MatchConditionModel> MatchConditions { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("priority")]
    [Required]
    public int Priority { get; set; }

    [JsonPropertyName("rateLimitDurationInMinutes")]
    public int? RateLimitDurationInMinutes { get; set; }

    [JsonPropertyName("rateLimitThreshold")]
    public int? RateLimitThreshold { get; set; }

    [JsonPropertyName("ruleType")]
    [Required]
    public RuleTypeConstant RuleType { get; set; }
}
