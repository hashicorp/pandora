using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsRevisions;


internal class ScaleRuleModel
{
    [JsonPropertyName("azureQueue")]
    public QueueScaleRuleModel? AzureQueue { get; set; }

    [JsonPropertyName("custom")]
    public CustomScaleRuleModel? Custom { get; set; }

    [JsonPropertyName("http")]
    public HttpScaleRuleModel? Http { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
