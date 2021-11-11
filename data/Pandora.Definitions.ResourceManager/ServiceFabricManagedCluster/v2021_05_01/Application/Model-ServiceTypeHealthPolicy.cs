using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.Application
{

    internal class ServiceTypeHealthPolicyModel
    {
        [JsonPropertyName("maxPercentUnhealthyPartitionsPerService")]
        [Required]
        public int MaxPercentUnhealthyPartitionsPerService { get; set; }

        [JsonPropertyName("maxPercentUnhealthyReplicasPerPartition")]
        [Required]
        public int MaxPercentUnhealthyReplicasPerPartition { get; set; }

        [JsonPropertyName("maxPercentUnhealthyServices")]
        [Required]
        public int MaxPercentUnhealthyServices { get; set; }
    }
}
