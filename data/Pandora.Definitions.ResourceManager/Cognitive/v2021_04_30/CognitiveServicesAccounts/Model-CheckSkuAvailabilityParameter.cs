using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.CognitiveServicesAccounts
{

    internal class CheckSkuAvailabilityParameterModel
    {
        [JsonPropertyName("kind")]
        [Required]
        public string Kind { get; set; }

        [JsonPropertyName("skus")]
        [Required]
        public List<string> Skus { get; set; }

        [JsonPropertyName("type")]
        [Required]
        public string Type { get; set; }
    }
}
