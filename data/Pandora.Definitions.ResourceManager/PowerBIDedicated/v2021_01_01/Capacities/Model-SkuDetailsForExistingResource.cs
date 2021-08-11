using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.Capacities
{

    internal class SkuDetailsForExistingResourceModel
    {
        [JsonPropertyName("sku")]
        public CapacitySkuModel? Sku { get; set; }
    }
}
