using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.CognitiveServicesAccounts;


internal class EncryptionModel
{
    [JsonPropertyName("keySource")]
    public KeySourceConstant? KeySource { get; set; }

    [JsonPropertyName("keyVaultProperties")]
    public KeyVaultPropertiesModel? KeyVaultProperties { get; set; }
}
