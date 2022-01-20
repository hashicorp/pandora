using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.VideoAnalyzer;


internal class VideoAnalyzerPropertiesUpdateModel
{
    [JsonPropertyName("encryption")]
    public AccountEncryptionModel? Encryption { get; set; }

    [JsonPropertyName("endpoints")]
    public List<EndpointModel>? Endpoints { get; set; }

    [JsonPropertyName("storageAccounts")]
    public List<StorageAccountModel>? StorageAccounts { get; set; }
}
