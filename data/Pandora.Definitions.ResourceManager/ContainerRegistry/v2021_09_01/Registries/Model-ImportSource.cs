using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Registries;


internal class ImportSourceModel
{
    [JsonPropertyName("credentials")]
    public ImportSourceCredentialsModel? Credentials { get; set; }

    [JsonPropertyName("registryUri")]
    public string? RegistryUri { get; set; }

    [JsonPropertyName("resourceId")]
    public string? ResourceId { get; set; }

    [JsonPropertyName("sourceImage")]
    [Required]
    public string SourceImage { get; set; }
}
