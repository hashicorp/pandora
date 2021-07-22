using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2019_10_01.Store
{
    internal class Create : LongRunningPutOperation
    {
        public override object? RequestObject()
        {
            return new CreateStoreInput();
        }

        public override ResourceID? ResourceId()
        {
            return new ConfigurationStoreId();
        }

        private class CreateStoreInput
        {
            [JsonPropertyName("location")]
            [Required]
            [ForceNew]
            public Location Location { get; set; }

            [JsonPropertyName("sku")]
            [Required]
            [ForceNew]
            public Sku Sku { get; set; }

            [JsonPropertyName("tags")]
            [Optional]
            public Tags Tags { get; set; }
        }
    }
}