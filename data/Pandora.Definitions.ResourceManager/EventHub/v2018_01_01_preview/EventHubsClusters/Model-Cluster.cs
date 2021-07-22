using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClusters
{

    internal class Cluster
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("location")]
        public Location? Location { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("properties")]
        public ClusterProperties? Properties { get; set; }

        [JsonPropertyName("sku")]
        public ClusterSku? Sku { get; set; }

        [JsonPropertyName("tags")]
        public Tags? Tags { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}
