using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.EventSubscriptions
{

    internal class AzureFunctionEventSubscriptionDestinationPropertiesModel
    {
        [JsonPropertyName("deliveryAttributeMappings")]
        public List<DeliveryAttributeMappingModel>? DeliveryAttributeMappings { get; set; }

        [JsonPropertyName("maxEventsPerBatch")]
        public int? MaxEventsPerBatch { get; set; }

        [JsonPropertyName("preferredBatchSizeInKilobytes")]
        public int? PreferredBatchSizeInKilobytes { get; set; }

        [JsonPropertyName("resourceId")]
        public string? ResourceId { get; set; }
    }
}
