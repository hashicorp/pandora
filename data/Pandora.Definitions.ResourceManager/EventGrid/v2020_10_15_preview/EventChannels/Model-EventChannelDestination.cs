using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.EventChannels
{

    internal class EventChannelDestinationModel
    {
        [JsonPropertyName("azureSubscriptionId")]
        public string? AzureSubscriptionId { get; set; }

        [JsonPropertyName("partnerTopicName")]
        public string? PartnerTopicName { get; set; }

        [JsonPropertyName("resourceGroup")]
        public string? ResourceGroup { get; set; }
    }
}
