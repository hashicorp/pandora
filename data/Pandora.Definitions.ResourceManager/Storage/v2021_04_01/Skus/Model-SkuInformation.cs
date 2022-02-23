using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.Skus;


internal class SkuInformationModel
{
    [JsonPropertyName("capabilities")]
    public List<SKUCapabilityModel>? Capabilities { get; set; }

    [JsonPropertyName("kind")]
    public KindConstant? Kind { get; set; }

    [JsonPropertyName("locations")]
    public List<string>? Locations { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public SkuNameConstant Name { get; set; }

    [JsonPropertyName("resourceType")]
    public string? ResourceType { get; set; }

    [JsonPropertyName("restrictions")]
    public List<RestrictionModel>? Restrictions { get; set; }

    [JsonPropertyName("tier")]
    public SkuTierConstant? Tier { get; set; }
}
