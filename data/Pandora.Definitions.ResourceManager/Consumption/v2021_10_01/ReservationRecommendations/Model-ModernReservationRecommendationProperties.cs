using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.ReservationRecommendations;


internal class ModernReservationRecommendationPropertiesModel
{
    [JsonPropertyName("costWithNoReservedInstances")]
    public AmountModel? CostWithNoReservedInstances { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("firstUsageDate")]
    public DateTime? FirstUsageDate { get; set; }

    [JsonPropertyName("instanceFlexibilityGroup")]
    public string? InstanceFlexibilityGroup { get; set; }

    [JsonPropertyName("instanceFlexibilityRatio")]
    public float? InstanceFlexibilityRatio { get; set; }

    [JsonPropertyName("location")]
    public CustomTypes.Location? Location { get; set; }

    [JsonPropertyName("lookBackPeriod")]
    public int? LookBackPeriod { get; set; }

    [JsonPropertyName("meterId")]
    public string? MeterId { get; set; }

    [JsonPropertyName("netSavings")]
    public AmountModel? NetSavings { get; set; }

    [JsonPropertyName("normalizedSize")]
    public string? NormalizedSize { get; set; }

    [JsonPropertyName("recommendedQuantity")]
    public float? RecommendedQuantity { get; set; }

    [JsonPropertyName("recommendedQuantityNormalized")]
    public float? RecommendedQuantityNormalized { get; set; }

    [JsonPropertyName("resourceType")]
    public string? ResourceType { get; set; }

    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    [JsonPropertyName("skuName")]
    public string? SkuName { get; set; }

    [JsonPropertyName("skuProperties")]
    public List<SkuPropertyModel>? SkuProperties { get; set; }

    [JsonPropertyName("subscriptionId")]
    public string? SubscriptionId { get; set; }

    [JsonPropertyName("term")]
    public string? Term { get; set; }

    [JsonPropertyName("totalCostWithReservedInstances")]
    public AmountModel? TotalCostWithReservedInstances { get; set; }
}
