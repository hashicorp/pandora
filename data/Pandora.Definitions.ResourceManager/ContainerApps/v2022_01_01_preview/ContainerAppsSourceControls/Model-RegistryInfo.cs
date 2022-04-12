using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsSourceControls;


internal class RegistryInfoModel
{
    [JsonPropertyName("registryPassword")]
    public string? RegistryPassword { get; set; }

    [JsonPropertyName("registryUrl")]
    public string? RegistryUrl { get; set; }

    [JsonPropertyName("registryUserName")]
    public string? RegistryUserName { get; set; }
}
