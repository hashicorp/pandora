using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.Service;

[ValueForType("ScalePartitionInstanceCount")]
internal class PartitionInstanceCountScaleMechanismModel : ScalingMechanismModel
{
    [JsonPropertyName("maxInstanceCount")]
    [Required]
    public int MaxInstanceCount { get; set; }

    [JsonPropertyName("minInstanceCount")]
    [Required]
    public int MinInstanceCount { get; set; }

    [JsonPropertyName("scaleIncrement")]
    [Required]
    public int ScaleIncrement { get; set; }
}
