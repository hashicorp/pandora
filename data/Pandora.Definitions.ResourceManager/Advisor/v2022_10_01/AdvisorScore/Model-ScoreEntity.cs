using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Advisor.v2022_10_01.AdvisorScore;


internal class ScoreEntityModel
{
    [JsonPropertyName("categoryCount")]
    public float? CategoryCount { get; set; }

    [JsonPropertyName("consumptionUnits")]
    public float? ConsumptionUnits { get; set; }

    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("impactedResourceCount")]
    public float? ImpactedResourceCount { get; set; }

    [JsonPropertyName("potentialScoreIncrease")]
    public float? PotentialScoreIncrease { get; set; }

    [JsonPropertyName("score")]
    public float? Score { get; set; }
}
