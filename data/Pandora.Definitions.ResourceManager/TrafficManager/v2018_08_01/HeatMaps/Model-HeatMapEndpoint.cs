using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.HeatMaps
{

    internal class HeatMapEndpoint
    {
        [JsonPropertyName("endpointId")]
        public int? EndpointId { get; set; }

        [JsonPropertyName("resourceId")]
        public string? ResourceId { get; set; }
    }
}
