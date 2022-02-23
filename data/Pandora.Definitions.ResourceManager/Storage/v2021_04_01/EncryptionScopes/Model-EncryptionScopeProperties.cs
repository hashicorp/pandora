using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.EncryptionScopes;


internal class EncryptionScopePropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationTime")]
    public DateTime? CreationTime { get; set; }

    [JsonPropertyName("keyVaultProperties")]
    public EncryptionScopeKeyVaultPropertiesModel? KeyVaultProperties { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedTime")]
    public DateTime? LastModifiedTime { get; set; }

    [JsonPropertyName("requireInfrastructureEncryption")]
    public bool? RequireInfrastructureEncryption { get; set; }

    [JsonPropertyName("source")]
    public EncryptionScopeSourceConstant? Source { get; set; }

    [JsonPropertyName("state")]
    public EncryptionScopeStateConstant? State { get; set; }
}
