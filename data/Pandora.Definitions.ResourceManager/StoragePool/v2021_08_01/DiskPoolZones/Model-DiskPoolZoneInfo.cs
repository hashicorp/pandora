using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.DiskPoolZones;


internal class DiskPoolZoneInfoModel
{
    [JsonPropertyName("additionalCapabilities")]
    public List<string>? AdditionalCapabilities { get; set; }

    [JsonPropertyName("availabilityZones")]
    public List<string>? AvailabilityZones { get; set; }

    [JsonPropertyName("sku")]
    public SkuModel? Sku { get; set; }
}
