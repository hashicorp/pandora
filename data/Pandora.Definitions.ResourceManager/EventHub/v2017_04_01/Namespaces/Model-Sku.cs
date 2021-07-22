using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.Namespaces
{

    internal class Sku
    {
        [JsonPropertyName("capacity")]
        public int Capacity { get; set; }

        [JsonPropertyName("name")]
        [Required]
        public SkuName Name { get; set; }

        [JsonPropertyName("tier")]
        public SkuTier Tier { get; set; }
    }
}
