using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_05_01.Service
{
    [ValueForType("Stateless")]
    internal class StatelessServicePropertiesModel : ServiceResourcePropertiesModel
    {
        [JsonPropertyName("instanceCount")]
        [Required]
        public int InstanceCount { get; set; }

        [JsonPropertyName("minInstanceCount")]
        public int? MinInstanceCount { get; set; }

        [JsonPropertyName("minInstancePercentage")]
        public int? MinInstancePercentage { get; set; }
    }
}
