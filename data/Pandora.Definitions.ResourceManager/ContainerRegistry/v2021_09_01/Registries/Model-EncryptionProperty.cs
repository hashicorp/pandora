using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Registries;


internal class EncryptionPropertyModel
{
    [JsonPropertyName("keyVaultProperties")]
    public KeyVaultPropertiesModel? KeyVaultProperties { get; set; }

    [JsonPropertyName("status")]
    public EncryptionStatusConstant? Status { get; set; }
}
