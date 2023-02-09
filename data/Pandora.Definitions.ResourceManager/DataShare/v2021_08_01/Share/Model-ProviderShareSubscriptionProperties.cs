using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2021_08_01.Share;


internal class ProviderShareSubscriptionPropertiesModel
{
    [JsonPropertyName("consumerEmail")]
    public string? ConsumerEmail { get; set; }

    [JsonPropertyName("consumerName")]
    public string? ConsumerName { get; set; }

    [JsonPropertyName("consumerTenantName")]
    public string? ConsumerTenantName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expirationDate")]
    public DateTime? ExpirationDate { get; set; }

    [JsonPropertyName("providerEmail")]
    public string? ProviderEmail { get; set; }

    [JsonPropertyName("providerName")]
    public string? ProviderName { get; set; }

    [JsonPropertyName("shareSubscriptionObjectId")]
    public string? ShareSubscriptionObjectId { get; set; }

    [JsonPropertyName("shareSubscriptionStatus")]
    public ShareSubscriptionStatusConstant? ShareSubscriptionStatus { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("sharedAt")]
    public DateTime? SharedAt { get; set; }
}
