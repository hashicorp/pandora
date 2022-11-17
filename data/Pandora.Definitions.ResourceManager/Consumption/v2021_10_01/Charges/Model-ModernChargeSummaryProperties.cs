using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.Charges;


internal class ModernChargeSummaryPropertiesModel
{
    [JsonPropertyName("azureCharges")]
    public AmountModel? AzureCharges { get; set; }

    [JsonPropertyName("billingAccountId")]
    public string? BillingAccountId { get; set; }

    [JsonPropertyName("billingPeriodId")]
    public string? BillingPeriodId { get; set; }

    [JsonPropertyName("billingProfileId")]
    public string? BillingProfileId { get; set; }

    [JsonPropertyName("chargesBilledSeparately")]
    public AmountModel? ChargesBilledSeparately { get; set; }

    [JsonPropertyName("customerId")]
    public string? CustomerId { get; set; }

    [JsonPropertyName("invoiceSectionId")]
    public string? InvoiceSectionId { get; set; }

    [JsonPropertyName("isInvoiced")]
    public bool? IsInvoiced { get; set; }

    [JsonPropertyName("marketplaceCharges")]
    public AmountModel? MarketplaceCharges { get; set; }

    [JsonPropertyName("usageEnd")]
    public string? UsageEnd { get; set; }

    [JsonPropertyName("usageStart")]
    public string? UsageStart { get; set; }
}
