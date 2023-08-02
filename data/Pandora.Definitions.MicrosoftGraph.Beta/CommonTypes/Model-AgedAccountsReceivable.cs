// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AgedAccountsReceivableModel
{
    [JsonPropertyName("agedAsOfDate")]
    public DateTime? AgedAsOfDate { get; set; }

    [JsonPropertyName("balanceDue")]
    public float? BalanceDue { get; set; }

    [JsonPropertyName("currencyCode")]
    public string? CurrencyCode { get; set; }

    [JsonPropertyName("currentAmount")]
    public float? CurrentAmount { get; set; }

    [JsonPropertyName("customerNumber")]
    public string? CustomerNumber { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("period1Amount")]
    public float? Period1Amount { get; set; }

    [JsonPropertyName("period2Amount")]
    public float? Period2Amount { get; set; }

    [JsonPropertyName("period3Amount")]
    public float? Period3Amount { get; set; }

    [JsonPropertyName("periodLengthFilter")]
    public string? PeriodLengthFilter { get; set; }
}
