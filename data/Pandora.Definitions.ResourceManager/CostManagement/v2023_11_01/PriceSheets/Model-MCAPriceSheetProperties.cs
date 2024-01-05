using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_11_01.PriceSheets;


internal class MCAPriceSheetPropertiesModel
{
    [JsonPropertyName("basePrice")]
    public string? BasePrice { get; set; }

    [JsonPropertyName("billingAccountID")]
    public string? BillingAccountID { get; set; }

    [JsonPropertyName("billingAccountName")]
    public string? BillingAccountName { get; set; }

    [JsonPropertyName("billingCurrency")]
    public string? BillingCurrency { get; set; }

    [JsonPropertyName("billingProfileId")]
    public string? BillingProfileId { get; set; }

    [JsonPropertyName("billingProfileName")]
    public string? BillingProfileName { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("effectiveEndDate")]
    public DateTime? EffectiveEndDate { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("effectiveStartDate")]
    public DateTime? EffectiveStartDate { get; set; }

    [JsonPropertyName("marketPrice")]
    public string? MarketPrice { get; set; }

    [JsonPropertyName("meterCategory")]
    public string? MeterCategory { get; set; }

    [JsonPropertyName("meterName")]
    public string? MeterName { get; set; }

    [JsonPropertyName("meterRegion")]
    public string? MeterRegion { get; set; }

    [JsonPropertyName("meterSubCategory")]
    public string? MeterSubCategory { get; set; }

    [JsonPropertyName("meterType")]
    public string? MeterType { get; set; }

    [JsonPropertyName("priceType")]
    public string? PriceType { get; set; }

    [JsonPropertyName("product")]
    public string? Product { get; set; }

    [JsonPropertyName("productId")]
    public string? ProductId { get; set; }

    [JsonPropertyName("serviceFamily")]
    public float? ServiceFamily { get; set; }

    [JsonPropertyName("skuId")]
    public string? SkuId { get; set; }

    [JsonPropertyName("term")]
    public string? Term { get; set; }

    [JsonPropertyName("tierMinimumUnits")]
    public string? TierMinimumUnits { get; set; }

    [JsonPropertyName("unitOfMeasure")]
    public string? UnitOfMeasure { get; set; }

    [JsonPropertyName("unitPrice")]
    public string? UnitPrice { get; set; }
}
