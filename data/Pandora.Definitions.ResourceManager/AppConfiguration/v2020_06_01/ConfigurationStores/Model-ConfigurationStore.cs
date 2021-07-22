using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.ConfigurationStores
{
    internal class ConfigurationStore
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("identity")]
        public ResourceIdentity? Identity { get; set; }

        [JsonPropertyName("location")]
        [Required]
        public Location Location { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("properties")]
        public ConfigurationStoreProperties? Properties { get; set; }

        [JsonPropertyName("sku")]
        [Required]
        public Sku Sku { get; set; }

        [JsonPropertyName("tags")]
        public Tags Tags { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}
