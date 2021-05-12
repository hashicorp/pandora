using System.Text.Json.Serialization;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.ResourceManager.EventHubs.v2018_01_01_preview.Namespace
{
    internal class Get : GetOperation
    {
        public override object? ResponseObject()
        {
            return new GetNamespace();
        }

        private class GetNamespace
        {
            [JsonPropertyName("location")]
            public Location Location { get; set; }
        
            [JsonPropertyName("properties")]
            public GetNamespaceProperties Properties { get; set; }
        
            [JsonPropertyName("sku")]
            public Sku Sku { get; set; }
        
            [JsonPropertyName("tags")]
            public Tags Tags { get; set; }
        }

        private class GetNamespaceProperties
        {
            [JsonPropertyName("isAutoInflateEnabled")]
            public bool IsAutoInflateEnabled { get; set; }
        
            [JsonPropertyName("serviceBusEndpoint")]
            public string ServiceBusEndpoint { get; set; }
        
            [JsonPropertyName("zoneRedundant")]
            public bool ZoneRedundant { get; set; }
        }
    }
}