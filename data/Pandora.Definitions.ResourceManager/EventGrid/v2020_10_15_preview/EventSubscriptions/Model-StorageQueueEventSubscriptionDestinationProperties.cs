using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.EventSubscriptions
{

    internal class StorageQueueEventSubscriptionDestinationPropertiesModel
    {
        [JsonPropertyName("queueMessageTimeToLiveInSeconds")]
        public int? QueueMessageTimeToLiveInSeconds { get; set; }

        [JsonPropertyName("queueName")]
        public string? QueueName { get; set; }

        [JsonPropertyName("resourceId")]
        public string? ResourceId { get; set; }
    }
}
