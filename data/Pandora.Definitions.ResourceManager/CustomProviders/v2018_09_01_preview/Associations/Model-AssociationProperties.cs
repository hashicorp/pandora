using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.CustomProviders.v2018_09_01_preview.Associations
{

    internal class AssociationPropertiesModel
    {
        [JsonPropertyName("provisioningState")]
        public ProvisioningStateConstant? ProvisioningState { get; set; }

        [JsonPropertyName("targetResourceId")]
        public string? TargetResourceId { get; set; }
    }
}
