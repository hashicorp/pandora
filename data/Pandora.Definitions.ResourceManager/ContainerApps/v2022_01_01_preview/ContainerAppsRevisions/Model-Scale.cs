using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsRevisions;


internal class ScaleModel
{
    [JsonPropertyName("maxReplicas")]
    public int? MaxReplicas { get; set; }

    [JsonPropertyName("minReplicas")]
    public int? MinReplicas { get; set; }

    [JsonPropertyName("rules")]
    public List<ScaleRuleModel>? Rules { get; set; }
}
