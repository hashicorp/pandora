using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.Balances;


internal class BalancePropertiesModel
{
    [JsonPropertyName("adjustmentDetails")]
    public List<BalancePropertiesAdjustmentDetailsInlinedModel>? AdjustmentDetails { get; set; }

    [JsonPropertyName("adjustments")]
    public float? Adjustments { get; set; }

    [JsonPropertyName("azureMarketplaceServiceCharges")]
    public float? AzureMarketplaceServiceCharges { get; set; }

    [JsonPropertyName("beginningBalance")]
    public float? BeginningBalance { get; set; }

    [JsonPropertyName("billingFrequency")]
    public BillingFrequencyConstant? BillingFrequency { get; set; }

    [JsonPropertyName("chargesBilledSeparately")]
    public float? ChargesBilledSeparately { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("endingBalance")]
    public float? EndingBalance { get; set; }

    [JsonPropertyName("newPurchases")]
    public float? NewPurchases { get; set; }

    [JsonPropertyName("newPurchasesDetails")]
    public List<BalancePropertiesNewPurchasesDetailsInlinedModel>? NewPurchasesDetails { get; set; }

    [JsonPropertyName("priceHidden")]
    public bool? PriceHidden { get; set; }

    [JsonPropertyName("serviceOverage")]
    public float? ServiceOverage { get; set; }

    [JsonPropertyName("totalOverage")]
    public float? TotalOverage { get; set; }

    [JsonPropertyName("totalUsage")]
    public float? TotalUsage { get; set; }

    [JsonPropertyName("utilized")]
    public float? Utilized { get; set; }
}
