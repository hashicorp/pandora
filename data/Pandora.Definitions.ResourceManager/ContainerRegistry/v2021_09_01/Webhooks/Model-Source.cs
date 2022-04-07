using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Webhooks;


internal class SourceModel
{
    [JsonPropertyName("addr")]
    public string? Addr { get; set; }

    [JsonPropertyName("instanceID")]
    public string? InstanceID { get; set; }
}
