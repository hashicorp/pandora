using System.Text.Json.Serialization;

namespace Pandora.Definitions.HandDefined.AADB2C.v2021_04_01_preview.Tenants
{
    internal class TenantPropertiesModel
    {
        [JsonPropertyName("countryCode")]
        public string? CountryCode { get; set; }
        
        [JsonPropertyName("billingConfig")]
        public BillingConfigModel? BillingConfig { get; set; }
        
        [JsonPropertyName("displayName")]
        public string? DisplayName { get; set; }
        
        [JsonPropertyName("tenantId")]
        public string? TenantId { get; }
    }
}