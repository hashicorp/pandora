using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_05_01.Service
{

    internal class ServiceCorrelationModel
    {
        [JsonPropertyName("scheme")]
        [Required]
        public ServiceCorrelationSchemeConstant Scheme { get; set; }

        [JsonPropertyName("serviceName")]
        [Required]
        public string ServiceName { get; set; }
    }
}
