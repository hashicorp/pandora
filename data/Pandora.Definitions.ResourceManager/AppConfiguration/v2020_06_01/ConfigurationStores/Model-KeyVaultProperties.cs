using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
    internal class KeyVaultProperties
    {
        [JsonPropertyName("identityClientId")]
        public string? IdentityClientId { get; set; }

        [JsonPropertyName("keyIdentifier")]
        public string? KeyIdentifier { get; set; }
    }
}
