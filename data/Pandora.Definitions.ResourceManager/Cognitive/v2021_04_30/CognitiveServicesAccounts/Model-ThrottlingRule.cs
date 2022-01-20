using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.CognitiveServicesAccounts;


internal class ThrottlingRuleModel
{
    [JsonPropertyName("count")]
    public float? Count { get; set; }

    [JsonPropertyName("dynamicThrottlingEnabled")]
    public bool? DynamicThrottlingEnabled { get; set; }

    [JsonPropertyName("key")]
    public string? Key { get; set; }

    [JsonPropertyName("matchPatterns")]
    public List<RequestMatchPatternModel>? MatchPatterns { get; set; }

    [JsonPropertyName("minCount")]
    public float? MinCount { get; set; }

    [JsonPropertyName("renewalPeriod")]
    public float? RenewalPeriod { get; set; }
}
