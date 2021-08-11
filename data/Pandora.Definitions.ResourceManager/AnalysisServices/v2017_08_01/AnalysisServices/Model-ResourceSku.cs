using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.AnalysisServices
{

    internal class ResourceSkuModel
    {
        [JsonPropertyName("capacity")]
        public int? Capacity { get; set; }

        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }

        [JsonPropertyName("tier")]
        public SkuTierConstant? Tier { get; set; }
    }
}
