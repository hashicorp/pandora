using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Webhooks;


internal class TargetModel
{
    [JsonPropertyName("digest")]
    public string? Digest { get; set; }

    [JsonPropertyName("length")]
    public int? Length { get; set; }

    [JsonPropertyName("mediaType")]
    public string? MediaType { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("repository")]
    public string? Repository { get; set; }

    [JsonPropertyName("size")]
    public int? Size { get; set; }

    [JsonPropertyName("tag")]
    public string? Tag { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
