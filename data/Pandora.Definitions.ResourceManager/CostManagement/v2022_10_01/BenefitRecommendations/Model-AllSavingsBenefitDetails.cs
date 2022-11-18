using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.BenefitRecommendations;


internal class AllSavingsBenefitDetailsModel
{
    [JsonPropertyName("averageUtilizationPercentage")]
    public float? AverageUtilizationPercentage { get; set; }

    [JsonPropertyName("benefitCost")]
    public float? BenefitCost { get; set; }

    [JsonPropertyName("commitmentAmount")]
    public float? CommitmentAmount { get; set; }

    [JsonPropertyName("coveragePercentage")]
    public float? CoveragePercentage { get; set; }

    [JsonPropertyName("overageCost")]
    public float? OverageCost { get; set; }

    [JsonPropertyName("savingsAmount")]
    public float? SavingsAmount { get; set; }

    [JsonPropertyName("savingsPercentage")]
    public float? SavingsPercentage { get; set; }

    [JsonPropertyName("totalCost")]
    public float? TotalCost { get; set; }

    [JsonPropertyName("wastageCost")]
    public float? WastageCost { get; set; }
}
