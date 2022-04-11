using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.DaprComponents;


internal class DaprComponentPropertiesModel
{
    [JsonPropertyName("componentType")]
    public string? ComponentType { get; set; }

    [JsonPropertyName("ignoreErrors")]
    public bool? IgnoreErrors { get; set; }

    [JsonPropertyName("initTimeout")]
    public string? InitTimeout { get; set; }

    [JsonPropertyName("metadata")]
    public List<DaprMetadataModel>? Metadata { get; set; }

    [JsonPropertyName("scopes")]
    public List<string>? Scopes { get; set; }

    [JsonPropertyName("secrets")]
    public List<SecretModel>? Secrets { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
