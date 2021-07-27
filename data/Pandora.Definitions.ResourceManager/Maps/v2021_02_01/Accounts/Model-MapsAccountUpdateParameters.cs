using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Accounts
{

    internal class MapsAccountUpdateParameters
    {
        [JsonPropertyName("kind")]
        public Kind? Kind { get; set; }

        [JsonPropertyName("properties")]
        public MapsAccountProperties? Properties { get; set; }

        [JsonPropertyName("sku")]
        public Sku? Sku { get; set; }

        [JsonPropertyName("tags")]
        public CustomTypes.Tags? Tags { get; set; }
    }
}
