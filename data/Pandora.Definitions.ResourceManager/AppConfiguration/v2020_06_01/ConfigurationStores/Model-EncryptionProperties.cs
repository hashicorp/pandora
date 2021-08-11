using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{

    internal class EncryptionPropertiesModel
    {
        [JsonPropertyName("keyVaultProperties")]
        public KeyVaultPropertiesModel? KeyVaultProperties { get; set; }
    }
}
