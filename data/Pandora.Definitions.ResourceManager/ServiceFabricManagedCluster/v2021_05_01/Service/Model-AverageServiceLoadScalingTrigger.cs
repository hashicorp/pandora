using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.Service
{
    [ValueForType("AverageServiceLoadTrigger")]
    internal class AverageServiceLoadScalingTriggerModel : ScalingTriggerModel
    {
        [JsonPropertyName("lowerLoadThreshold")]
        [Required]
        public float LowerLoadThreshold { get; set; }

        [JsonPropertyName("metricName")]
        [Required]
        public string MetricName { get; set; }

        [JsonPropertyName("scaleInterval")]
        [Required]
        public string ScaleInterval { get; set; }

        [JsonPropertyName("upperLoadThreshold")]
        [Required]
        public float UpperLoadThreshold { get; set; }

        [JsonPropertyName("useOnlyPrimaryLoad")]
        [Required]
        public bool UseOnlyPrimaryLoad { get; set; }
    }
}
