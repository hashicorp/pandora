using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.Lots;


internal class LotPropertiesModel
{
    [JsonPropertyName("billingCurrency")]
    public string? BillingCurrency { get; set; }

    [JsonPropertyName("closedBalance")]
    public AmountModel? ClosedBalance { get; set; }

    [JsonPropertyName("closedBalanceInBillingCurrency")]
    public AmountWithExchangeRateModel? ClosedBalanceInBillingCurrency { get; set; }

    [JsonPropertyName("creditCurrency")]
    public string? CreditCurrency { get; set; }

    [JsonPropertyName("eTag")]
    public string? ETag { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expirationDate")]
    public DateTime? ExpirationDate { get; set; }

    [JsonPropertyName("originalAmount")]
    public AmountModel? OriginalAmount { get; set; }

    [JsonPropertyName("originalAmountInBillingCurrency")]
    public AmountWithExchangeRateModel? OriginalAmountInBillingCurrency { get; set; }

    [JsonPropertyName("poNumber")]
    public string? PoNumber { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("purchasedDate")]
    public DateTime? PurchasedDate { get; set; }

    [JsonPropertyName("reseller")]
    public ResellerModel? Reseller { get; set; }

    [JsonPropertyName("source")]
    public LotSourceConstant? Source { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startDate")]
    public DateTime? StartDate { get; set; }

    [JsonPropertyName("status")]
    public StatusConstant? Status { get; set; }
}
