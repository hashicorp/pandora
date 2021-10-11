using System.Text.Json.Serialization;

namespace Pandora.Definitions.HandDefined.AADB2C.v2021_04_01_preview.Tenants
{
    internal class TenantModel
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("location")]
        public Location Location { get; set; }
        
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        
        [JsonPropertyName("properties")]
        public TenantPropertiesModel? Properties { get; set; }
        
        [JsonPropertyName("sku")]
        public SkuModel? Sku { get; set; }

        [JsonPropertyName("tags")]
        public CustomTypes.Tags? Tags { get; set; }
        
        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}