using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2019_10_01.Charges;


internal class LegacyChargeSummaryPropertiesModel
{
    [JsonPropertyName("azureCharges")]
    public float? AzureCharges { get; set; }

    [JsonPropertyName("azureMarketplaceCharges")]
    public float? AzureMarketplaceCharges { get; set; }

    [JsonPropertyName("billingPeriodId")]
    public string? BillingPeriodId { get; set; }

    [JsonPropertyName("chargesBilledSeparately")]
    public float? ChargesBilledSeparately { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("usageEnd")]
    public string? UsageEnd { get; set; }

    [JsonPropertyName("usageStart")]
    public string? UsageStart { get; set; }
}
