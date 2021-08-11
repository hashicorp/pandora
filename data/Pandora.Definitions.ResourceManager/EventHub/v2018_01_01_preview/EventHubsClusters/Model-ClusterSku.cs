using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClusters
{

    internal class ClusterSkuModel
    {
        [JsonPropertyName("capacity")]
        public int? Capacity { get; set; }

        [JsonPropertyName("name")]
        [Required]
        public ClusterSkuNameConstant Name { get; set; }
    }
}
