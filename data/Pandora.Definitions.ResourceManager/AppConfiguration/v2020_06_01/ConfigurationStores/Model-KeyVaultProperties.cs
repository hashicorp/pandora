using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{

    internal class KeyVaultPropertiesModel
    {
        [JsonPropertyName("identityClientId")]
        public string? IdentityClientId { get; set; }

        [JsonPropertyName("keyIdentifier")]
        public string? KeyIdentifier { get; set; }
    }
}
