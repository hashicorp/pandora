using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.Services
{

    internal class ScalingPolicyModel
    {
        [JsonPropertyName("scalingMechanism")]
        [Required]
        public ScalingMechanismModel ScalingMechanism { get; set; }

        [JsonPropertyName("scalingTrigger")]
        [Required]
        public ScalingTriggerModel ScalingTrigger { get; set; }
    }
}
