using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ServiceFabricManagedCluster.v2021_05_01.ApplicationType
{

    internal class ApplicationTypeResourcePropertiesModel
    {
        [JsonPropertyName("provisioningState")]
        public string? ProvisioningState { get; set; }
    }
}
