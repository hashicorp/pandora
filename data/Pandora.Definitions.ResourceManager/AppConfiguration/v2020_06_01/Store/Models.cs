using System.ComponentModel;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01.Store
{
    internal class EncryptionProperties
    {
        [JsonPropertyName("keyVaultProperties")]
        public KeyVaultProperties KeyVault { get; set; }
    }
    
    internal class GetStore
    {
        [JsonPropertyName("location")]
        public Location Location { get; set; }
        
        [JsonPropertyName("identity")]
        public Identity Identity { get; set; }

        [JsonPropertyName("properties")]
        public StoreProperties Properties { get; set; }
            
        [JsonPropertyName("sku")]
        public Sku Sku { get; set; }
            
        [JsonPropertyName("tags")]
        public Tags Tags { get; set; }
    }

    internal class StoreProperties
    {
        [JsonPropertyName("encryption")]
        public EncryptionProperties? Encryption { get; set; }
            
        [JsonPropertyName("endpoint")]
        public string Endpoint { get; set; }
            
        [JsonPropertyName("publicNetworkAccess")]
        public PublicNetworkAccess PublicNetworkAccess { get; set; }
    }

    internal class KeyVaultProperties
    {
        [JsonPropertyName("keyIdentifier")]
        [Optional]
        public string? KeyIdentifier { get; set; }
        
        [JsonPropertyName("identityClientId")]
        [Optional]
        public string? IdentityClientId { get; set; }
    }

    internal class Identity
    {
        [JsonPropertyName("principalId")]
        public string PrincipalId { get; set; }
        
        [JsonPropertyName("tenantId")]
        public string TenantId { get; set; }
        
        [JsonPropertyName("type")]
        [Required]
        public IdentityType Type { get; set; }

        internal enum IdentityType
        {
            [Description("None")]
            None,
            
            [Description("SystemAssigned")]
            SystemAssigned
        }
    }

    internal enum PublicNetworkAccess
    {
        [Description("Disabled")]
        Disabled,
        
        [Description("Enabled")]
        Enabled
    }
    
    internal class Sku
    {
        [JsonPropertyName("name")]
        public SkuName Name { get; set; }

        internal enum SkuName
        {
            [Description("free")]
            Free,
            
            [Description("standard")]
            Standard
        }
    }
}