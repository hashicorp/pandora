using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.VerifiedPartners;


internal class VerifiedPartnerPropertiesModel
{
    [JsonPropertyName("organizationName")]
    public string? OrganizationName { get; set; }

    [JsonPropertyName("partnerDisplayName")]
    public string? PartnerDisplayName { get; set; }

    [JsonPropertyName("partnerRegistrationImmutableId")]
    public string? PartnerRegistrationImmutableId { get; set; }

    [JsonPropertyName("partnerTopicDetails")]
    public PartnerDetailsModel? PartnerTopicDetails { get; set; }

    [JsonPropertyName("provisioningState")]
    public VerifiedPartnerProvisioningStateConstant? ProvisioningState { get; set; }
}
