using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.AggregatedCost;


internal class ManagementGroupAggregatedCostPropertiesModel
{
    [JsonPropertyName("azureCharges")]
    public float? AzureCharges { get; set; }

    [JsonPropertyName("billingPeriodId")]
    public string? BillingPeriodId { get; set; }

    [JsonPropertyName("chargesBilledSeparately")]
    public float? ChargesBilledSeparately { get; set; }

    [JsonPropertyName("children")]
    public List<ManagementGroupAggregatedCostResultModel>? Children { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("excludedSubscriptions")]
    public List<string>? ExcludedSubscriptions { get; set; }

    [JsonPropertyName("includedSubscriptions")]
    public List<string>? IncludedSubscriptions { get; set; }

    [JsonPropertyName("marketplaceCharges")]
    public float? MarketplaceCharges { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("usageEnd")]
    public DateTime? UsageEnd { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("usageStart")]
    public DateTime? UsageStart { get; set; }
}
