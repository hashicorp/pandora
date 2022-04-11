using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsRevisions;


internal class ContainerResourcesModel
{
    [JsonPropertyName("cpu")]
    public float? Cpu { get; set; }

    [JsonPropertyName("ephemeralStorage")]
    public string? EphemeralStorage { get; set; }

    [JsonPropertyName("memory")]
    public string? Memory { get; set; }
}
