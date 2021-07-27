using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Maps.v2021_02_01.Accounts
{

    internal class Sku
    {
        [JsonPropertyName("name")]
        [Required]
        public Name Name { get; set; }

        [JsonPropertyName("tier")]
        public string? Tier { get; set; }
    }
}
