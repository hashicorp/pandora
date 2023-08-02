using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.PartnerTopics;


internal class PartnerTopicPropertiesModel
{
    [JsonPropertyName("activationState")]
    public PartnerTopicActivationStateConstant? ActivationState { get; set; }

    [JsonPropertyName("eventTypeInfo")]
    public EventTypeInfoModel? EventTypeInfo { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expirationTimeIfNotActivatedUtc")]
    public DateTime? ExpirationTimeIfNotActivatedUtc { get; set; }

    [JsonPropertyName("messageForActivation")]
    public string? MessageForActivation { get; set; }

    [JsonPropertyName("partnerRegistrationImmutableId")]
    public string? PartnerRegistrationImmutableId { get; set; }

    [JsonPropertyName("partnerTopicFriendlyDescription")]
    public string? PartnerTopicFriendlyDescription { get; set; }

    [JsonPropertyName("provisioningState")]
    public PartnerTopicProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }
}
