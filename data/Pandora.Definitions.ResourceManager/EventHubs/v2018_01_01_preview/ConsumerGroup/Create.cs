using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.ResourceManager.EventHubs.v2018_01_01_preview.ConsumerGroup
{
    internal class Create : PutOperation
    {
        public override object? RequestObject()
        {
            return new CreateConsumerGroupInput();
        }

        private class CreateConsumerGroupInput
        {
            [JsonPropertyName("properties")]
            public CreateConsumerGroupProperties Properties { get; set; }
        }
        
        private class CreateConsumerGroupProperties
        {
            [JsonPropertyName("userMetadata")]
            [Optional]
            //[FieldValidation(Type = FieldValidationType.MaxLength, MaxLength = 1024)]
            public string UserMetadata { get; set; }
        }
    }
}