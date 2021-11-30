using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.Domains
{

    internal class DomainUpdateParametersModel
    {
        [JsonPropertyName("identity")]
        public CustomTypes.SystemUserAssignedIdentityMap? Identity { get; set; }

        [JsonPropertyName("properties")]
        public DomainUpdateParameterPropertiesModel? Properties { get; set; }

        [JsonPropertyName("sku")]
        public ResourceSkuModel? Sku { get; set; }

        [JsonPropertyName("tags")]
        public CustomTypes.Tags? Tags { get; set; }
    }
}
