using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2019_10_01.Credits;


internal class CreditSummaryPropertiesModel
{
    [JsonPropertyName("balanceSummary")]
    public CreditBalanceSummaryModel? BalanceSummary { get; set; }

    [JsonPropertyName("billingCurrency")]
    public string? BillingCurrency { get; set; }

    [JsonPropertyName("creditCurrency")]
    public string? CreditCurrency { get; set; }

    [JsonPropertyName("expiredCredit")]
    public AmountModel? ExpiredCredit { get; set; }

    [JsonPropertyName("pendingCreditAdjustments")]
    public AmountModel? PendingCreditAdjustments { get; set; }

    [JsonPropertyName("pendingEligibleCharges")]
    public AmountModel? PendingEligibleCharges { get; set; }

    [JsonPropertyName("reseller")]
    public ResellerModel? Reseller { get; set; }
}
