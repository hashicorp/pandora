using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.CustomProviders.v2018_09_01_preview.CustomResourceProvider
{

    internal class CustomRPManifestPropertiesModel
    {
        [JsonPropertyName("actions")]
        public List<CustomRPActionRouteDefinitionModel>? Actions { get; set; }

        [JsonPropertyName("provisioningState")]
        public ProvisioningStateConstant? ProvisioningState { get; set; }

        [JsonPropertyName("resourceTypes")]
        public List<CustomRPResourceTypeRouteDefinitionModel>? ResourceTypes { get; set; }

        [JsonPropertyName("validations")]
        public List<CustomRPValidationsModel>? Validations { get; set; }
    }
}
