using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.CustomProviders.v2018_09_01_preview.CustomResourceProvider
{

    internal class CustomRPResourceTypeRouteDefinitionModel
    {
        [JsonPropertyName("endpoint")]
        [Required]
        public string Endpoint { get; set; }

        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }

        [JsonPropertyName("routingType")]
        public ResourceTypeRoutingConstant? RoutingType { get; set; }
    }
}
