using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.ResourceManager.EventHubs.v2018_01_01_preview.Namespace
{
    internal class Create : LongRunningPutOperation
    {
        public override object? RequestObject()
        {
            return new CreateNamespaceInput();
        }

        private class CreateNamespaceInput
        {
            [JsonPropertyName("location")]
            [Required]
            [ForceNew]
            public Location Location { get; set; }
        
            [JsonPropertyName("properties")]
            [Required]
            [ForceNew]
            public CreateNamespaceProperties Properties { get; set; }
        
            [JsonPropertyName("sku")]
            [Required]
            [ForceNew]
            public Sku Sku { get; set; }
        
            [JsonPropertyName("tags")]
            [Optional]
            [SupportsDeltaUpdate]
            public Tags Tags { get; set; }
        }

        private class CreateNamespaceProperties
        {
            [JsonPropertyName("isAutoInflateEnabled")]
            [Optional]
            public bool IsAutoInflateEnabled { get; set; }
        
            [JsonPropertyName("ZoneRedundant")]
            [Optional]
            public bool ZoneRedundant { get; set; }
        }
    }
}