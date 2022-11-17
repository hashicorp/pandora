using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.Events;


internal class EventPropertiesModel
{
    [JsonPropertyName("adjustments")]
    public AmountModel? Adjustments { get; set; }

    [JsonPropertyName("adjustmentsInBillingCurrency")]
    public AmountWithExchangeRateModel? AdjustmentsInBillingCurrency { get; set; }

    [JsonPropertyName("billingCurrency")]
    public string? BillingCurrency { get; set; }

    [JsonPropertyName("billingProfileDisplayName")]
    public string? BillingProfileDisplayName { get; set; }

    [JsonPropertyName("billingProfileId")]
    public string? BillingProfileId { get; set; }

    [JsonPropertyName("canceledCredit")]
    public AmountModel? CanceledCredit { get; set; }

    [JsonPropertyName("charges")]
    public AmountModel? Charges { get; set; }

    [JsonPropertyName("chargesInBillingCurrency")]
    public AmountWithExchangeRateModel? ChargesInBillingCurrency { get; set; }

    [JsonPropertyName("closedBalance")]
    public AmountModel? ClosedBalance { get; set; }

    [JsonPropertyName("closedBalanceInBillingCurrency")]
    public AmountWithExchangeRateModel? ClosedBalanceInBillingCurrency { get; set; }

    [JsonPropertyName("creditCurrency")]
    public string? CreditCurrency { get; set; }

    [JsonPropertyName("creditExpired")]
    public AmountModel? CreditExpired { get; set; }

    [JsonPropertyName("creditExpiredInBillingCurrency")]
    public AmountWithExchangeRateModel? CreditExpiredInBillingCurrency { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("eTag")]
    public string? ETag { get; set; }

    [JsonPropertyName("eventType")]
    public EventTypeConstant? EventType { get; set; }

    [JsonPropertyName("invoiceNumber")]
    public string? InvoiceNumber { get; set; }

    [JsonPropertyName("lotId")]
    public string? LotId { get; set; }

    [JsonPropertyName("lotSource")]
    public string? LotSource { get; set; }

    [JsonPropertyName("newCredit")]
    public AmountModel? NewCredit { get; set; }

    [JsonPropertyName("newCreditInBillingCurrency")]
    public AmountWithExchangeRateModel? NewCreditInBillingCurrency { get; set; }

    [JsonPropertyName("reseller")]
    public ResellerModel? Reseller { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("transactionDate")]
    public DateTime? TransactionDate { get; set; }
}
