using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Purview.v2020_12_01_preview.Account;


internal class AccessKeysModel
{
    [JsonPropertyName("atlasKafkaPrimaryEndpoint")]
    public string? AtlasKafkaPrimaryEndpoint { get; set; }

    [JsonPropertyName("atlasKafkaSecondaryEndpoint")]
    public string? AtlasKafkaSecondaryEndpoint { get; set; }
}
