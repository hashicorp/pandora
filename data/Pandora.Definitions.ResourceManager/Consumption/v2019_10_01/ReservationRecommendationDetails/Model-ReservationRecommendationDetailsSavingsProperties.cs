using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2019_10_01.ReservationRecommendationDetails;


internal class ReservationRecommendationDetailsSavingsPropertiesModel
{
    [JsonPropertyName("calculatedSavings")]
    public List<ReservationRecommendationDetailsCalculatedSavingsPropertiesModel>? CalculatedSavings { get; set; }

    [JsonPropertyName("lookBackPeriod")]
    public int? LookBackPeriod { get; set; }

    [JsonPropertyName("recommendedQuantity")]
    public float? RecommendedQuantity { get; set; }

    [JsonPropertyName("reservationOrderTerm")]
    public string? ReservationOrderTerm { get; set; }

    [JsonPropertyName("savingsType")]
    public string? SavingsType { get; set; }

    [JsonPropertyName("unitOfMeasure")]
    public string? UnitOfMeasure { get; set; }
}
