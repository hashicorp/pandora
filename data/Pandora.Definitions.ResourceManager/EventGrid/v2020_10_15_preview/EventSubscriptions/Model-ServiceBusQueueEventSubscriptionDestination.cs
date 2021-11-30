using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.EventSubscriptions
{
    [ValueForType("ServiceBusQueue")]
    internal class ServiceBusQueueEventSubscriptionDestinationModel : EventSubscriptionDestinationModel
    {
        [JsonPropertyName("properties")]
        public ServiceBusQueueEventSubscriptionDestinationPropertiesModel? Properties { get; set; }
    }
}
