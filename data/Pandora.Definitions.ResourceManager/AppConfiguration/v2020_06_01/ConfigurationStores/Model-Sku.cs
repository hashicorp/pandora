using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
    internal class Sku
    {
        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }
    }
}
