using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.Clusters
{

    internal class Cluster
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("properties")]
        [Required]
        public ClusterProperties Properties { get; set; }

        [JsonPropertyName("sku")]
        [Required]
        public Sku Sku { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}
