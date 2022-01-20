using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.Namespaces;


internal class EncryptionModel
{
    [JsonPropertyName("keySource")]
    public KeySourceConstant? KeySource { get; set; }

    [JsonPropertyName("keyVaultProperties")]
    public List<KeyVaultPropertiesModel>? KeyVaultProperties { get; set; }
}
