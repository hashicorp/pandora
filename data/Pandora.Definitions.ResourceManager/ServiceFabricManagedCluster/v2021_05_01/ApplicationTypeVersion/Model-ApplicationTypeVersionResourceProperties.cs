using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.ApplicationTypeVersion
{

    internal class ApplicationTypeVersionResourcePropertiesModel
    {
        [JsonPropertyName("appPackageUrl")]
        [Required]
        public string AppPackageUrl { get; set; }

        [JsonPropertyName("provisioningState")]
        public string? ProvisioningState { get; set; }
    }
}
