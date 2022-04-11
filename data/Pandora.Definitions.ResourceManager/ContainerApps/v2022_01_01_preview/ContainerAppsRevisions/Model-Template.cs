using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsRevisions;


internal class TemplateModel
{
    [JsonPropertyName("containers")]
    public List<ContainerModel>? Containers { get; set; }

    [JsonPropertyName("revisionSuffix")]
    public string? RevisionSuffix { get; set; }

    [JsonPropertyName("scale")]
    public ScaleModel? Scale { get; set; }

    [JsonPropertyName("volumes")]
    public List<VolumeModel>? Volumes { get; set; }
}
