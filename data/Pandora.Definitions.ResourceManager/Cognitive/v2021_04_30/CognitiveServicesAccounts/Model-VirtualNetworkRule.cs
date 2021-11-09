using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.CognitiveServicesAccounts
{

    internal class VirtualNetworkRuleModel
    {
        [JsonPropertyName("id")]
        [Required]
        public string Id { get; set; }

        [JsonPropertyName("ignoreMissingVnetServiceEndpoint")]
        public bool? IgnoreMissingVnetServiceEndpoint { get; set; }

        [JsonPropertyName("state")]
        public string? State { get; set; }
    }
}
