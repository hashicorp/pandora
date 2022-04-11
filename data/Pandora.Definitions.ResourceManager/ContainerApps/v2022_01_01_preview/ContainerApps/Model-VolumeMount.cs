using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerApps;


internal class VolumeMountModel
{
    [JsonPropertyName("mountPath")]
    public string? MountPath { get; set; }

    [JsonPropertyName("volumeName")]
    public string? VolumeName { get; set; }
}
