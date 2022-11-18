using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.ReservationRecommendationDetails;


internal class ReservationRecommendationDetailsResourcePropertiesModel
{
    [JsonPropertyName("appliedScopes")]
    public List<string>? AppliedScopes { get; set; }

    [JsonPropertyName("onDemandRate")]
    public float? OnDemandRate { get; set; }

    [JsonPropertyName("product")]
    public string? Product { get; set; }

    [JsonPropertyName("region")]
    public string? Region { get; set; }

    [JsonPropertyName("reservationRate")]
    public float? ReservationRate { get; set; }

    [JsonPropertyName("resourceType")]
    public string? ResourceType { get; set; }
}
