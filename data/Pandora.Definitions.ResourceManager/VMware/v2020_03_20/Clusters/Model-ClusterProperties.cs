using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.Clusters
{

    internal class ClusterProperties
    {
        [JsonPropertyName("clusterId")]
        public int? ClusterId { get; set; }

        [JsonPropertyName("clusterSize")]
        [Required]
        public int ClusterSize { get; set; }

        [JsonPropertyName("hosts")]
        public List<string>? Hosts { get; set; }

        [JsonPropertyName("provisioningState")]
        public ClusterProvisioningState? ProvisioningState { get; set; }
    }
}
