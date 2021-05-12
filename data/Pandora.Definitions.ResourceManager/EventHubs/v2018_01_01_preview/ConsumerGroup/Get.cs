using System.Text.Json.Serialization;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.ResourceManager.EventHubs.v2018_01_01_preview.ConsumerGroup
{
    public class Get : GetOperation
    {
        public override object? ResponseObject()
        {
            return new GetConsumerGroup();
        }

        private class GetConsumerGroup
        {
            [JsonPropertyName("properties")]
            public GetConsumerGroupProperties Properties { get; set; }
        }
        
        private class GetConsumerGroupProperties
        {
            [JsonPropertyName("createdAt")]
            public string CreatedAt { get; set; }
            
            [JsonPropertyName("updatedAt")]
            public string UpdatedAt { get; set; }
            
            [JsonPropertyName("userMetadata")]
            public string UserMetadata { get; set; }
        }
    }
}