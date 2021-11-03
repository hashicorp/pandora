using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.CognitiveServicesAccounts
{

    internal class SkuAvailabilityModel
    {
        [JsonPropertyName("kind")]
        public string? Kind { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("reason")]
        public string? Reason { get; set; }

        [JsonPropertyName("skuAvailable")]
        public bool? SkuAvailable { get; set; }

        [JsonPropertyName("skuName")]
        public string? SkuName { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}
