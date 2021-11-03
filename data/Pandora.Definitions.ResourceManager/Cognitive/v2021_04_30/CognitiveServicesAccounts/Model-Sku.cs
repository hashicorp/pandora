using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.CognitiveServicesAccounts
{

    internal class SkuModel
    {
        [JsonPropertyName("capacity")]
        public int? Capacity { get; set; }

        [JsonPropertyName("family")]
        public string? Family { get; set; }

        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }

        [JsonPropertyName("size")]
        public string? Size { get; set; }

        [JsonPropertyName("tier")]
        public SkuTierConstant? Tier { get; set; }
    }
}
