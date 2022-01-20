using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.DataLakeStore.v2016_11_01.Accounts;


internal class KeyVaultMetaInfoModel
{
    [JsonPropertyName("encryptionKeyName")]
    [Required]
    public string EncryptionKeyName { get; set; }

    [JsonPropertyName("encryptionKeyVersion")]
    [Required]
    public string EncryptionKeyVersion { get; set; }

    [JsonPropertyName("keyVaultResourceId")]
    [Required]
    public string KeyVaultResourceId { get; set; }
}
