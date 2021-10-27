using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_05_01.FrontDoors
{

    internal class BackendPoolPropertiesModel
    {
        [JsonPropertyName("backends")]
        public List<BackendModel>? Backends { get; set; }

        [JsonPropertyName("healthProbeSettings")]
        public SubResourceModel? HealthProbeSettings { get; set; }

        [JsonPropertyName("loadBalancingSettings")]
        public SubResourceModel? LoadBalancingSettings { get; set; }

        [JsonPropertyName("resourceState")]
        public FrontDoorResourceStateConstant? ResourceState { get; set; }
    }
}
