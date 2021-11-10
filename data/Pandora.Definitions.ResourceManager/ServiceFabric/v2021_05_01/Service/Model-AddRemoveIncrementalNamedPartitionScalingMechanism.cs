using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_05_01.Service
{
    [ValueForType("AddRemoveIncrementalNamedPartition")]
    internal class AddRemoveIncrementalNamedPartitionScalingMechanismModel : ScalingMechanismModel
    {
        [JsonPropertyName("maxPartitionCount")]
        [Required]
        public int MaxPartitionCount { get; set; }

        [JsonPropertyName("minPartitionCount")]
        [Required]
        public int MinPartitionCount { get; set; }

        [JsonPropertyName("scaleIncrement")]
        [Required]
        public int ScaleIncrement { get; set; }
    }
}
