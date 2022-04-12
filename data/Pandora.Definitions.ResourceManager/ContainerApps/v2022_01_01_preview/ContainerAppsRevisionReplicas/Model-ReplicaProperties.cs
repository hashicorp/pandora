using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsRevisionReplicas;


internal class ReplicaPropertiesModel
{
    [JsonPropertyName("containers")]
    public List<ReplicaContainerModel>? Containers { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdTime")]
    public DateTime? CreatedTime { get; set; }
}
