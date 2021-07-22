using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.EventHubsClusters
{

    internal class ClusterListResult
    {
        [JsonPropertyName("nextLink")]
        public string? NextLink { get; set; }

        [JsonPropertyName("value")]
        public List<Cluster>? Value { get; set; }
    }
}
