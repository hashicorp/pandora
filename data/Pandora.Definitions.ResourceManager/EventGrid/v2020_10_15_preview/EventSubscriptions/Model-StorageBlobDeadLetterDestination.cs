using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.EventSubscriptions
{
    [ValueForType("StorageBlob")]
    internal class StorageBlobDeadLetterDestinationModel : DeadLetterDestinationModel
    {
        [JsonPropertyName("properties")]
        public StorageBlobDeadLetterDestinationPropertiesModel? Properties { get; set; }
    }
}
