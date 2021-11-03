using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.CognitiveServicesAccounts
{

    internal class KeyVaultPropertiesModel
    {
        [JsonPropertyName("identityClientId")]
        public string? IdentityClientId { get; set; }

        [JsonPropertyName("keyName")]
        public string? KeyName { get; set; }

        [JsonPropertyName("keyVaultUri")]
        public string? KeyVaultUri { get; set; }

        [JsonPropertyName("keyVersion")]
        public string? KeyVersion { get; set; }
    }
}
