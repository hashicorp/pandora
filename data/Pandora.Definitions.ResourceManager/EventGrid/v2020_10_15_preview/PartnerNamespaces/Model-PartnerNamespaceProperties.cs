using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.PartnerNamespaces
{

    internal class PartnerNamespacePropertiesModel
    {
        [JsonPropertyName("endpoint")]
        public string? Endpoint { get; set; }

        [JsonPropertyName("partnerRegistrationFullyQualifiedId")]
        public string? PartnerRegistrationFullyQualifiedId { get; set; }

        [JsonPropertyName("provisioningState")]
        public PartnerNamespaceProvisioningStateConstant? ProvisioningState { get; set; }
    }
}
