using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.StorageAccounts;


internal class KeyVaultPropertiesModel
{
    [JsonPropertyName("currentVersionedKeyIdentifier")]
    public string? CurrentVersionedKeyIdentifier { get; set; }

    [JsonPropertyName("keyname")]
    public string? Keyname { get; set; }

    [JsonPropertyName("keyvaulturi")]
    public string? Keyvaulturi { get; set; }

    [JsonPropertyName("keyversion")]
    public string? Keyversion { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastKeyRotationTimestamp")]
    public DateTime? LastKeyRotationTimestamp { get; set; }
}
