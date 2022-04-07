using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2021_09_01.Registries;


internal class SkuModel
{
    [JsonPropertyName("name")]
    [Required]
    public SkuNameConstant Name { get; set; }

    [JsonPropertyName("tier")]
    public SkuTierConstant? Tier { get; set; }
}
