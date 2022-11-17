using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.ReservationRecommendationDetails;


internal class ReservationRecommendationDetailsPropertiesModel
{
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("resource")]
    public ReservationRecommendationDetailsResourcePropertiesModel? Resource { get; set; }

    [JsonPropertyName("resourceGroup")]
    public string? ResourceGroup { get; set; }

    [JsonPropertyName("savings")]
    public ReservationRecommendationDetailsSavingsPropertiesModel? Savings { get; set; }

    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    [JsonPropertyName("usage")]
    public ReservationRecommendationDetailsUsagePropertiesModel? Usage { get; set; }
}
