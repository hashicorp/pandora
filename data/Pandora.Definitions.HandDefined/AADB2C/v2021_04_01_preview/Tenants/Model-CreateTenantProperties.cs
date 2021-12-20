using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;

namespace Pandora.Definitions.HandDefined.AADB2C.v2021_04_01_preview.Tenants
{
    internal class CreateTenantPropertiesModel
    {
        [JsonPropertyName("countryCode")]
        [Required]
        public string? CountryCode { get; set; }
        
        [JsonPropertyName("displayName")]
        [Required]
        public string? DisplayName { get; set; }
    }
}