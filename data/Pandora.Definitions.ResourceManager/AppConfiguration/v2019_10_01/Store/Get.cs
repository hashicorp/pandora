using System.Text.Json.Serialization;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2019_10_01.Store
{
    internal class Get : GetOperation
    {
        public override ResourceID? ResourceId()
        {
            return new ConfigurationStoreId();
        }
        
        public override object? ResponseObject()
        {
            return new GetStore();
        }

        private class GetStore
        {
            [JsonPropertyName("location")]
            public Location Location { get; set; }
            
            [JsonPropertyName("properties")]
            public GetStoreProperties Properties { get; set; }
            
            [JsonPropertyName("sku")]
            public Sku Sku { get; set; }
            
            [JsonPropertyName("tags")]
            public Tags Tags { get; set; }
        }

        private class GetStoreProperties
        {
            [JsonPropertyName("endpoint")]
            public string ConfigurationStoreEndpoint { get; set; }
        }
    }
}