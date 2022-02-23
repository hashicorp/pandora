using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.StorageAccounts;


internal class EncryptionModel
{
    [JsonPropertyName("identity")]
    public EncryptionIdentityModel? Identity { get; set; }

    [JsonPropertyName("keySource")]
    [Required]
    public KeySourceConstant KeySource { get; set; }

    [JsonPropertyName("keyvaultproperties")]
    public KeyVaultPropertiesModel? Keyvaultproperties { get; set; }

    [JsonPropertyName("requireInfrastructureEncryption")]
    public bool? RequireInfrastructureEncryption { get; set; }

    [JsonPropertyName("services")]
    public EncryptionServicesModel? Services { get; set; }
}
