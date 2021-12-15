using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{

    internal class ConfigurationStoreUpdateParametersModel
    {
        [JsonPropertyName("identity")]
        public CustomTypes.SystemAndUserAssignedIdentityMap? Identity { get; set; }

        [JsonPropertyName("properties")]
        public ConfigurationStorePropertiesUpdateParametersModel? Properties { get; set; }

        [JsonPropertyName("sku")]
        public SkuModel? Sku { get; set; }

        [JsonPropertyName("tags")]
        public CustomTypes.Tags? Tags { get; set; }
    }
}
