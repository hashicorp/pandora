using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.Namespaces
{

    internal class KeyVaultProperties
    {
        [JsonPropertyName("keyName")]
        public string? KeyName { get; set; }

        [JsonPropertyName("keyVaultUri")]
        public string? KeyVaultUri { get; set; }

        [JsonPropertyName("keyVersion")]
        public string? KeyVersion { get; set; }
    }
}
