using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Accounts
{

    internal class MapsAccountUpdateParametersModel
    {
        [JsonPropertyName("kind")]
        public KindConstant? Kind { get; set; }

        [JsonPropertyName("properties")]
        public MapsAccountPropertiesModel? Properties { get; set; }

        [JsonPropertyName("sku")]
        public SkuModel? Sku { get; set; }

        [JsonPropertyName("tags")]
        public CustomTypes.Tags? Tags { get; set; }
    }
}
