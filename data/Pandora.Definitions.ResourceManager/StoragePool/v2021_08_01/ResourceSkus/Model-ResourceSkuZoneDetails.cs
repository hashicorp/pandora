using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.ResourceSkus;


internal class ResourceSkuZoneDetailsModel
{
    [JsonPropertyName("capabilities")]
    public List<ResourceSkuCapabilityModel>? Capabilities { get; set; }

    [JsonPropertyName("name")]
    public List<string>? Name { get; set; }
}
