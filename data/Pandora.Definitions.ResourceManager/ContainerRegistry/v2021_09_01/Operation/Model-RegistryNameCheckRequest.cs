using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Operation;


internal class RegistryNameCheckRequestModel
{
    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("type")]
    [Required]
    public ContainerRegistryResourceTypeConstant Type { get; set; }
}
