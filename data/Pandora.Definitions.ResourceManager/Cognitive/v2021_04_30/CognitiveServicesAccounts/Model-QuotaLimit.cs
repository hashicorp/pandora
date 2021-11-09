using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.CognitiveServicesAccounts
{

    internal class QuotaLimitModel
    {
        [JsonPropertyName("count")]
        public float? Count { get; set; }

        [JsonPropertyName("renewalPeriod")]
        public float? RenewalPeriod { get; set; }

        [JsonPropertyName("rules")]
        public List<ThrottlingRuleModel>? Rules { get; set; }
    }
}
