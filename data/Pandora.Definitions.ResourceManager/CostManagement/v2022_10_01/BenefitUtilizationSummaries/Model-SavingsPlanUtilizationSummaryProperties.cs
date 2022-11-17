using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.BenefitUtilizationSummaries;


internal class SavingsPlanUtilizationSummaryPropertiesModel
{
    [JsonPropertyName("armSkuName")]
    public string? ArmSkuName { get; set; }

    [JsonPropertyName("avgUtilizationPercentage")]
    public float? AvgUtilizationPercentage { get; set; }

    [JsonPropertyName("benefitId")]
    public string? BenefitId { get; set; }

    [JsonPropertyName("benefitOrderId")]
    public string? BenefitOrderId { get; set; }

    [JsonPropertyName("benefitType")]
    public BenefitKindConstant? BenefitType { get; set; }

    [JsonPropertyName("maxUtilizationPercentage")]
    public float? MaxUtilizationPercentage { get; set; }

    [JsonPropertyName("minUtilizationPercentage")]
    public float? MinUtilizationPercentage { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("usageDate")]
    public DateTime? UsageDate { get; set; }
}
