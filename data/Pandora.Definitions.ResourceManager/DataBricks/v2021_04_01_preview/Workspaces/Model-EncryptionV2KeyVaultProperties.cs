using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.DataBricks.v2021_04_01_preview.Workspaces
{

    internal class EncryptionV2KeyVaultPropertiesModel
    {
        [JsonPropertyName("keyName")]
        [Required]
        public string KeyName { get; set; }

        [JsonPropertyName("keyVaultUri")]
        [Required]
        public string KeyVaultUri { get; set; }

        [JsonPropertyName("keyVersion")]
        [Required]
        public string KeyVersion { get; set; }
    }
}
