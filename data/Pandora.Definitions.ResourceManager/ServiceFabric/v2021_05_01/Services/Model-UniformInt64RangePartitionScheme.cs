using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_05_01.Services
{
    [ValueForType("UniformInt64Range")]
    internal class UniformInt64RangePartitionSchemeModel : PartitionModel
    {
        [JsonPropertyName("count")]
        [Required]
        public int Count { get; set; }

        [JsonPropertyName("highKey")]
        [Required]
        public int HighKey { get; set; }

        [JsonPropertyName("lowKey")]
        [Required]
        public int LowKey { get; set; }
    }
}
