using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.PartnerRegistrations
{

    internal class PartnerRegistrationPropertiesModel
    {
        [JsonPropertyName("authorizedAzureSubscriptionIds")]
        public List<string>? AuthorizedAzureSubscriptionIds { get; set; }

        [JsonPropertyName("customerServiceUri")]
        public string? CustomerServiceUri { get; set; }

        [JsonPropertyName("logoUri")]
        public string? LogoUri { get; set; }

        [JsonPropertyName("longDescription")]
        public string? LongDescription { get; set; }

        [JsonPropertyName("partnerCustomerServiceExtension")]
        public string? PartnerCustomerServiceExtension { get; set; }

        [JsonPropertyName("partnerCustomerServiceNumber")]
        public string? PartnerCustomerServiceNumber { get; set; }

        [JsonPropertyName("partnerName")]
        public string? PartnerName { get; set; }

        [JsonPropertyName("partnerResourceTypeDescription")]
        public string? PartnerResourceTypeDescription { get; set; }

        [JsonPropertyName("partnerResourceTypeDisplayName")]
        public string? PartnerResourceTypeDisplayName { get; set; }

        [JsonPropertyName("partnerResourceTypeName")]
        public string? PartnerResourceTypeName { get; set; }

        [JsonPropertyName("provisioningState")]
        public PartnerRegistrationProvisioningStateConstant? ProvisioningState { get; set; }

        [JsonPropertyName("setupUri")]
        public string? SetupUri { get; set; }

        [JsonPropertyName("visibilityState")]
        public PartnerRegistrationVisibilityStateConstant? VisibilityState { get; set; }
    }
}
