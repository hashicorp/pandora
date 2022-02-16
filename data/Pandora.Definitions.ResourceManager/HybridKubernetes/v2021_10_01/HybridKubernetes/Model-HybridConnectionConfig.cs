using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.HybridKubernetes.v2021_10_01.HybridKubernetes;


internal class HybridConnectionConfigModel
{
    [JsonPropertyName("expirationTime")]
    public int? ExpirationTime { get; set; }

    [JsonPropertyName("hybridConnectionName")]
    public string? HybridConnectionName { get; set; }

    [JsonPropertyName("relay")]
    public string? Relay { get; set; }

    [JsonPropertyName("token")]
    public string? Token { get; set; }
}
