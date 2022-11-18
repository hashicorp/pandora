using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.ReservationRecommendationDetails;


internal class ReservationRecommendationDetailsCalculatedSavingsPropertiesModel
{
    [JsonPropertyName("onDemandCost")]
    public float? OnDemandCost { get; set; }

    [JsonPropertyName("overageCost")]
    public float? OverageCost { get; set; }

    [JsonPropertyName("quantity")]
    public float? Quantity { get; set; }

    [JsonPropertyName("reservationCost")]
    public float? ReservationCost { get; set; }

    [JsonPropertyName("reservedUnitCount")]
    public float? ReservedUnitCount { get; set; }

    [JsonPropertyName("savings")]
    public float? Savings { get; set; }

    [JsonPropertyName("totalReservationCost")]
    public float? TotalReservationCost { get; set; }
}
