using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.BenefitRecommendations;


internal abstract class BenefitRecommendationPropertiesModel
{
    [JsonPropertyName("allRecommendationDetails")]
    public AllSavingsListModel? AllRecommendationDetails { get; set; }

    [JsonPropertyName("armSkuName")]
    public string? ArmSkuName { get; set; }

    [JsonPropertyName("commitmentGranularity")]
    public GrainConstant? CommitmentGranularity { get; set; }

    [JsonPropertyName("costWithoutBenefit")]
    public float? CostWithoutBenefit { get; set; }

    [JsonPropertyName("currencyCode")]
    public string? CurrencyCode { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("firstConsumptionDate")]
    public DateTime? FirstConsumptionDate { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastConsumptionDate")]
    public DateTime? LastConsumptionDate { get; set; }

    [JsonPropertyName("lookBackPeriod")]
    public LookBackPeriodConstant? LookBackPeriod { get; set; }

    [JsonPropertyName("recommendationDetails")]
    public AllSavingsBenefitDetailsModel? RecommendationDetails { get; set; }

    [JsonPropertyName("scope")]
    [ProvidesTypeHint]
    [Required]
    public ScopeConstant Scope { get; set; }

    [JsonPropertyName("term")]
    public TermConstant? Term { get; set; }

    [JsonPropertyName("totalHours")]
    public int? TotalHours { get; set; }

    [JsonPropertyName("usage")]
    public RecommendationUsageDetailsModel? Usage { get; set; }
}
