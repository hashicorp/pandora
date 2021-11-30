using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.EventChannels
{

    internal class EventChannelPropertiesModel
    {
        [JsonPropertyName("destination")]
        public EventChannelDestinationModel? Destination { get; set; }

        [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
        [JsonPropertyName("expirationTimeIfNotActivatedUtc")]
        public DateTime? ExpirationTimeIfNotActivatedUtc { get; set; }

        [JsonPropertyName("filter")]
        public EventChannelFilterModel? Filter { get; set; }

        [JsonPropertyName("partnerTopicFriendlyDescription")]
        public string? PartnerTopicFriendlyDescription { get; set; }

        [JsonPropertyName("partnerTopicReadinessState")]
        public PartnerTopicReadinessStateConstant? PartnerTopicReadinessState { get; set; }

        [JsonPropertyName("provisioningState")]
        public EventChannelProvisioningStateConstant? ProvisioningState { get; set; }

        [JsonPropertyName("source")]
        public EventChannelSourceModel? Source { get; set; }
    }
}
