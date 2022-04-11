using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsAuthConfigs;


internal class NonceModel
{
    [JsonPropertyName("nonceExpirationInterval")]
    public string? NonceExpirationInterval { get; set; }

    [JsonPropertyName("validateNonce")]
    public bool? ValidateNonce { get; set; }
}
