using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2019_10_01.ReservationRecommendationDetails;


internal class ReservationRecommendationDetailsUsagePropertiesModel
{
    [JsonPropertyName("firstConsumptionDate")]
    public string? FirstConsumptionDate { get; set; }

    [JsonPropertyName("lastConsumptionDate")]
    public string? LastConsumptionDate { get; set; }

    [JsonPropertyName("lookBackUnitType")]
    public string? LookBackUnitType { get; set; }

    [JsonPropertyName("usageData")]
    public List<float>? UsageData { get; set; }

    [JsonPropertyName("usageGrain")]
    public string? UsageGrain { get; set; }
}
