// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class SubscribedSkuModel
{
    [JsonPropertyName("accountId")]
    public string? AccountId { get; set; }

    [JsonPropertyName("accountName")]
    public string? AccountName { get; set; }

    [JsonPropertyName("appliesTo")]
    public string? AppliesTo { get; set; }

    [JsonPropertyName("capabilityStatus")]
    public string? CapabilityStatus { get; set; }

    [JsonPropertyName("consumedUnits")]
    public int? ConsumedUnits { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("prepaidUnits")]
    public LicenseUnitsDetailModel? PrepaidUnits { get; set; }

    [JsonPropertyName("servicePlans")]
    public List<ServicePlanInfoModel>? ServicePlans { get; set; }

    [JsonPropertyName("skuId")]
    public string? SkuId { get; set; }

    [JsonPropertyName("skuPartNumber")]
    public string? SkuPartNumber { get; set; }

    [JsonPropertyName("subscriptionIds")]
    public List<string>? SubscriptionIds { get; set; }
}
