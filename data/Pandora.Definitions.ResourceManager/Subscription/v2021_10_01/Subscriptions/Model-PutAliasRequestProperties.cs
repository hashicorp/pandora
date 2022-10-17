using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Subscription.v2021_10_01.Subscriptions;


internal class PutAliasRequestPropertiesModel
{
    [JsonPropertyName("additionalProperties")]
    public PutAliasRequestAdditionalPropertiesModel? AdditionalProperties { get; set; }

    [JsonPropertyName("billingScope")]
    public string? BillingScope { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("resellerId")]
    public string? ResellerId { get; set; }

    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; set; }

    [JsonPropertyName("workload")]
    public WorkloadConstant? Workload { get; set; }
}
