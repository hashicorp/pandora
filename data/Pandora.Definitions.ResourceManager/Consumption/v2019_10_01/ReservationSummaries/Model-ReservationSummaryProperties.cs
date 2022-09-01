using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2019_10_01.ReservationSummaries;


internal class ReservationSummaryPropertiesModel
{
    [JsonPropertyName("avgUtilizationPercentage")]
    public float? AvgUtilizationPercentage { get; set; }

    [JsonPropertyName("kind")]
    public string? Kind { get; set; }

    [JsonPropertyName("maxUtilizationPercentage")]
    public float? MaxUtilizationPercentage { get; set; }

    [JsonPropertyName("minUtilizationPercentage")]
    public float? MinUtilizationPercentage { get; set; }

    [JsonPropertyName("purchasedQuantity")]
    public float? PurchasedQuantity { get; set; }

    [JsonPropertyName("remainingQuantity")]
    public float? RemainingQuantity { get; set; }

    [JsonPropertyName("reservationId")]
    public string? ReservationId { get; set; }

    [JsonPropertyName("reservationOrderId")]
    public string? ReservationOrderId { get; set; }

    [JsonPropertyName("reservedHours")]
    public float? ReservedHours { get; set; }

    [JsonPropertyName("skuName")]
    public string? SkuName { get; set; }

    [JsonPropertyName("totalReservedQuantity")]
    public float? TotalReservedQuantity { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("usageDate")]
    public DateTime? UsageDate { get; set; }

    [JsonPropertyName("usedHours")]
    public float? UsedHours { get; set; }

    [JsonPropertyName("usedQuantity")]
    public float? UsedQuantity { get; set; }

    [JsonPropertyName("utilizedPercentage")]
    public float? UtilizedPercentage { get; set; }
}
