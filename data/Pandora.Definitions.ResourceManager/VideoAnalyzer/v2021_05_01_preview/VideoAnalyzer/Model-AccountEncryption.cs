using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.VideoAnalyzer;


internal class AccountEncryptionModel
{
    [JsonPropertyName("identity")]
    public ResourceIdentityModel? Identity { get; set; }

    [JsonPropertyName("keyVaultProperties")]
    public KeyVaultPropertiesModel? KeyVaultProperties { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("type")]
    [Required]
    public AccountEncryptionKeyTypeConstant Type { get; set; }
}
