using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30.Skus;


internal class ResourceSkuRestrictionInfoModel
{
    [JsonPropertyName("locations")]
    public List<string>? Locations { get; set; }

    [JsonPropertyName("zones")]
    public List<string>? Zones { get; set; }
}
