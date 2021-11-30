using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.PartnerTopics
{

    internal class PartnerTopicPropertiesModel
    {
        [JsonPropertyName("activationState")]
        public PartnerTopicActivationStateConstant? ActivationState { get; set; }

        [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
        [JsonPropertyName("expirationTimeIfNotActivatedUtc")]
        public DateTime? ExpirationTimeIfNotActivatedUtc { get; set; }

        [JsonPropertyName("partnerTopicFriendlyDescription")]
        public string? PartnerTopicFriendlyDescription { get; set; }

        [JsonPropertyName("provisioningState")]
        public PartnerTopicProvisioningStateConstant? ProvisioningState { get; set; }

        [JsonPropertyName("source")]
        public string? Source { get; set; }
    }
}
