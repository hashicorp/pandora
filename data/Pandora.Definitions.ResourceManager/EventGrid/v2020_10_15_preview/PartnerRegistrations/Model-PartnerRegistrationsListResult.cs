using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.PartnerRegistrations
{

    internal class PartnerRegistrationsListResultModel
    {
        [JsonPropertyName("nextLink")]
        public string? NextLink { get; set; }

        [JsonPropertyName("value")]
        public List<PartnerRegistrationModel>? Value { get; set; }
    }
}
