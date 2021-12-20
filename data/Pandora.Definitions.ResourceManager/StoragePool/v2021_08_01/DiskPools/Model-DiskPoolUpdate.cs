using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.DiskPools
{

    internal class DiskPoolUpdateModel
    {
        [JsonPropertyName("managedBy")]
        public string? ManagedBy { get; set; }

        [JsonPropertyName("managedByExtended")]
        public List<string>? ManagedByExtended { get; set; }

        [JsonPropertyName("properties")]
        [Required]
        public DiskPoolUpdatePropertiesModel Properties { get; set; }

        [JsonPropertyName("sku")]
        public SkuModel? Sku { get; set; }

        [JsonPropertyName("tags")]
        public CustomTypes.Tags? Tags { get; set; }
    }
}
