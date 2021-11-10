using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_05_01.Services
{

    internal class ServiceLoadMetricModel
    {
        [JsonPropertyName("defaultLoad")]
        public int? DefaultLoad { get; set; }

        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }

        [JsonPropertyName("primaryDefaultLoad")]
        public int? PrimaryDefaultLoad { get; set; }

        [JsonPropertyName("secondaryDefaultLoad")]
        public int? SecondaryDefaultLoad { get; set; }

        [JsonPropertyName("weight")]
        public ServiceLoadMetricWeightConstant? Weight { get; set; }
    }
}
