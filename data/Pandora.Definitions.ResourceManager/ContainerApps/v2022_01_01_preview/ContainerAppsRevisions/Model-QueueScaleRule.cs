using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsRevisions;


internal class QueueScaleRuleModel
{
    [JsonPropertyName("auth")]
    public List<ScaleRuleAuthModel>? Auth { get; set; }

    [JsonPropertyName("queueLength")]
    public int? QueueLength { get; set; }

    [JsonPropertyName("queueName")]
    public string? QueueName { get; set; }
}
