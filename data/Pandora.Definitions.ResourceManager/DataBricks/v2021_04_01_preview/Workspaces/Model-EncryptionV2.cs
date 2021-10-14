using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.DataBricks.v2021_04_01_preview.Workspaces
{

    internal class EncryptionV2Model
    {
        [JsonPropertyName("keySource")]
        [Required]
        public EncryptionKeySourceConstant KeySource { get; set; }

        [JsonPropertyName("keyVaultProperties")]
        public EncryptionV2KeyVaultPropertiesModel? KeyVaultProperties { get; set; }
    }
}
