using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.HandDefined.AADB2C.v2021_04_01_preview.Tenants
{
    internal class CreateTenantModel
    {
        [JsonPropertyName("location")]
        [Required]
        public Location Location { get; set; }
        
        [JsonPropertyName("properties")]
        [Required]
        public TenantPropertiesForCreate? Properties { get; set; }
        
        [JsonPropertyName("sku")]
        [Required]
        public SkuModel? Sku { get; set; }
        
        [JsonPropertyName("tags")]
        public CustomTypes.Tags? Tags { get; set; }
    }
}