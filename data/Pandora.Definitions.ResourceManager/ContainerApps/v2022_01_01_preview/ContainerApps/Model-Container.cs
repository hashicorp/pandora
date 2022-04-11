using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerApps;


internal class ContainerModel
{
    [JsonPropertyName("args")]
    public List<string>? Args { get; set; }

    [JsonPropertyName("command")]
    public List<string>? Command { get; set; }

    [JsonPropertyName("env")]
    public List<EnvironmentVarModel>? Env { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("probes")]
    public List<ContainerAppProbeModel>? Probes { get; set; }

    [JsonPropertyName("resources")]
    public ContainerResourcesModel? Resources { get; set; }

    [JsonPropertyName("volumeMounts")]
    public List<VolumeMountModel>? VolumeMounts { get; set; }
}
