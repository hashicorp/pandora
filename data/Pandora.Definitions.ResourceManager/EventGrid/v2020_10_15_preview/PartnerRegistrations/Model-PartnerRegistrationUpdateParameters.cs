using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.PartnerRegistrations
{

    internal class PartnerRegistrationUpdateParametersModel
    {
        [JsonPropertyName("authorizedAzureSubscriptionIds")]
        public List<string>? AuthorizedAzureSubscriptionIds { get; set; }

        [JsonPropertyName("logoUri")]
        public string? LogoUri { get; set; }

        [JsonPropertyName("partnerTopicTypeDescription")]
        public string? PartnerTopicTypeDescription { get; set; }

        [JsonPropertyName("partnerTopicTypeDisplayName")]
        public string? PartnerTopicTypeDisplayName { get; set; }

        [JsonPropertyName("partnerTopicTypeName")]
        public string? PartnerTopicTypeName { get; set; }

        [JsonPropertyName("setupUri")]
        public string? SetupUri { get; set; }

        [JsonPropertyName("tags")]
        public CustomTypes.Tags? Tags { get; set; }
    }
}
