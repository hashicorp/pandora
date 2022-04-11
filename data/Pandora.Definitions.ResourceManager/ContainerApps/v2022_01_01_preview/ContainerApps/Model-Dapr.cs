using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerApps;


internal class DaprModel
{
    [JsonPropertyName("appId")]
    public string? AppId { get; set; }

    [JsonPropertyName("appPort")]
    public int? AppPort { get; set; }

    [JsonPropertyName("appProtocol")]
    public AppProtocolConstant? AppProtocol { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }
}
